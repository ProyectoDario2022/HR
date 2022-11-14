using HR.API.Models;
using HR.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using HR.API.Data;
using HR.API.Data.Entities;
using HR.Common.Enums;
using Microsoft.AspNetCore.Identity;
using HR.Common.Models;

namespace HR.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        private readonly IMailHelper _mailHelper;

        //TODO falta IBlobHelper blobHelper 
        public AccountController(IUserHelper userHelper,DataContext context,ICombosHelper combosHelper,IMailHelper mailHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _combosHelper = combosHelper;
            _mailHelper = mailHelper;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if(result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty,"Email or Contraseña incorrectos");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult NotAuthorized()
        {
            return View();
        }

        public IActionResult Register()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                Funciones = _combosHelper.GetComboFunciones(),
                Id = Guid.NewGuid().ToString()//agregue esto id
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register (AddUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                Guid imageId=Guid.Empty;
                //TODO falta imagen

                if(model.ImageFile!=null)
                {
                   // imageId = await _blobHelper.UPloadBlobAsync(model.ImageFile, "users");
                }
                User user = await _userHelper.AddUserAsync(model, imageId,UserType.User);
                if(user==null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usao por otro usuario.");
                    model.Funciones=_combosHelper.GetComboFunciones();
                    return View(model);
                }
                /*LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username,
                };
                var result2=await _userHelper.LoginAsync(loginViewModel);
                if(result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }*/

                string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                string tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(
                    $"{model.FirstName} {model.LastName}",
                    model.Username,
                    "Hoja De Ruta - Confirmación de Email",
                    $"<h1>Hoja De Ruta  - Confirmación de Email</h1>" +
                        $"Para habilitar el usuario por favor hacer click en el siguiente link:, " +
                        $"<hr/><br/><p><a href = \"{tokenLink}\">Confirmar Email</a></p>");
                if (response.IsSuccess)
                {
                    ViewBag.Message="Usuario registrado. Para poder ingresar al sistema, siga las instrucciones que han sido enviadas a su correo.";
                    return View(model);
                }

                ModelState.AddModelError(string.Empty, response.Message);

            }
            model.Funciones = _combosHelper.GetComboFunciones();
            return View(model);
        }
        public async Task<IActionResult> ChangeUser()
        {
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            if(user==null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel
            {
                Direccion = user.Direccion,
                Document = user.Document,
                Funciones = _combosHelper.GetComboFunciones(),
                FuncionId=user.Funcion.Id,
                Id =user.Id,
                ImageId = user.ImageId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
               //ReclamoTecnicos = user.ReclamoTecnicos,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = model.ImageId;
                //TODO falta imagen 
                /*
                if(model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(ModelState.ImageFile, "users");
                }*/

                User user = await _userHelper.GetUserAsync(User.Identity.Name);

                user.Direccion = model.Direccion;
                user.Document = model.Document;
                user.Funcion = await _context.Funciones.FindAsync(model.FuncionId);
                user.ImageId = imageId;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                    //ReclamoTecnicos = user.ReclamoTecnicos,
                
                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index","Home");
            }
            model.Funciones=_combosHelper.GetComboFunciones();  
            return View(model);
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userHelper.GetUserAsync(User.Identity.Name);
                if(user!=null)
                {
                    IdentityResult result=await _userHelper.ChangePasswordAsync(user,model.OldPassword,model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(ChangeUser));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Usuario no Encontrado");
                    }
                }

            }
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            User user = await _userHelper.GetUserAsync(new Guid(userId));
            if (user == null)
            {
                return NotFound();
            }

            IdentityResult result = await _userHelper.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            return View();
        }
        public IActionResult RecoverPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userHelper.GetUserAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "El correo ingresado no corresponde a ningún usuario.");
                    return View(model);
                }

                string myToken = await _userHelper.GeneratePasswordResetTokenAsync(user);
                string link = Url.Action(
                    "ResetPassword",
                    "Account",
                    new { token = myToken }, protocol: HttpContext.Request.Scheme);
                _mailHelper.SendMail($"{model.Email}",model.Email,
                    "Hoja de Ruta - Reseteo de contraseña",
                    $"<h1>Hoja de Ruta - Reseteo de contraseña</h1>" +
                    $"Para establecer una nueva contraseña haga clic en el siguiente enlace:</br></br>" +
                    $"<a href = \"{link}\">Cambio de Contraseña</a>"
                    );

                ViewBag.Message = "Las instrucciones para el cambio de contraseña han sido enviadas a su email.";
                return View();

            }

            return View(model);
        }

        public IActionResult ResetPassword(string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            User user = await _userHelper.GetUserAsync(model.UserName);
            if (user != null)
            {
                IdentityResult result = await _userHelper.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Contaseña cambiada.";
                    return View();
                }

                ViewBag.Message = "Error cambiando la contraseña.";
                return View(model);
            }

            ViewBag.Message = "Usuario no encontrado.";
            return View(model);
        }
    }
}
