﻿using HR.API.Models;
using HR.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using HR.API.Data;
using HR.API.Data.Entities;
using HR.Common.Enums;

namespace HR.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        //TODO falta IBlobHelper blobHelper 
        public AccountController(IUserHelper userHelper,DataContext context,ICombosHelper combosHelper)
        {
            _userHelper = userHelper;
            _context = context;
            _combosHelper = combosHelper;
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
                LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username,
                };
                var result2=await _userHelper.LoginAsync(loginViewModel);
                if(result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
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


    }
}
