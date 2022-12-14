using HR.API.Data;
using HR.API.Data.Entities;
using HR.API.Helpers;
using HR.API.Models;
using HR.Common.Enums;
using HR.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IMailHelper _mailHelper;

        // private readonly IBlodHelper _blobHelper;

        public UsersController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper,
         IConverterHelper converterHelper,IMailHelper mailHelper)//, IBlodHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _mailHelper = mailHelper;
            //  _blobHelper = blobHelper;
        }
        public async Task<IActionResult> Index()
        {
            DateTime dia = new DateTime();
            dia = DateTime.Parse("02/03/04");
            List<Data.Entities.User>? tecnicos = await _context.Users.Where(x => x.UserType == UserType.User)
                      .Include(x => x.ReclamoTecnicos)
                      .ThenInclude(x => x.Reclamo)
                      .Include(x => x.Funcion)
                //.Select(x => new { ReclamoTecnicos = x, Reclamos = x.ReclamoTecnicos.Where(e => e.Reclamo.Fecha == dia) })
                .ToListAsync();
            return View(tecnicos);
        }
        public IActionResult Create()
         {
             UserViewModel model = new UserViewModel
             {
                 Funciones = _combosHelper.GetComboFunciones()
             };
             return View(model);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {//TODO:falta colocar la imagen del blob
                Guid imageId = Guid.Empty;
                if(model.ImageFile!=null)
                {
                  //  imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }
                User user = await _converterHelper.ToUserAsync(model, imageId, true);
                user.UserType = UserType.User;
                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());

                string myToken = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                string tokenLink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = myToken
                }, protocol: HttpContext.Request.Scheme);

                Response response = _mailHelper.SendMail(
                    $"{model.FirstName} {model.LastName}",
                    model.Email,
                    "Hoja De Ruta - Confirmación de Email",
                    $"<h1>Hoja De Ruta  - Confirmación de Email</h1>" +
                        $"Para habilitar el usuario por favor hacer click en el siguiente link:, " +
                        $"<hr/><br/><p><a href = \"{tokenLink}\">Confirmar Email</a></p>");

                    return RedirectToAction(nameof(Index));
            }
            model.Funciones= _combosHelper.GetComboFunciones();
            return View(model);
        }

       
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            User user = await _userHelper.GetUserAsync(Guid.Parse(id));
            if (user == null)
            {
                return NotFound();
            }
            UserViewModel model = _converterHelper.ToUserViewModel(user);

            return View(model);
        }

        // POST: /Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                   Guid imageId=model.ImageId;
                    if(model.ImageFile!=null)
                    {
                        imageId = model.ImageId;// await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                    }

                    User user = await _converterHelper.ToUserAsync(model, imageId, false);
                    await _userHelper.UpdateUserAsync(user);

                    return RedirectToAction(nameof(Index));
               
            }

            model.Funciones = _combosHelper.GetComboFunciones();
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            User user=await _userHelper.GetUserAsync(Guid.Parse(id));
            if (user == null)
            {
                return NotFound();
            }
           
            //TODO falta blob
            
            // await _blobHelper.DeleteBlobAsync(user.ImageId,"users");
            await _userHelper.DeleteUserAsync(user);
            return RedirectToAction(nameof(Index));
        }
    
    
    
    }


}
