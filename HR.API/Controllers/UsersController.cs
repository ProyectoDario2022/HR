using HR.API.Data;
using HR.API.Helpers;
using HR.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly DataContext _context;
       // private readonly IUrlHelper _userHelper;
      //  private readonly ICombosHelper _combosHelper;

        public UsersController(DataContext context)//, IUrlHelper userHelper, ICombosHelper combosHelper)
        //  IConverterHelper converterHelper,IBlodHelper blobHelper)
        {
            _context = context;
          //  _userHelper = userHelper;
         //   _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            DateTime dia = new DateTime();
            dia = DateTime.Parse("02/03/04");
            var tecnicos = await _context.Users.Where(x => x.UserType == UserType.User)
                      .Include(x => x.ReclamoTecnicos)
                      .ThenInclude(x => x.Reclamo)
                      .Include(c => c.Funcion)
                //.Select(x => new { ReclamoTecnicos = x, Reclamos = x.ReclamoTecnicos.Where(e => e.Reclamo.Fecha == dia) })
                .ToListAsync();
            return View(tecnicos);
        }
       /* public IActionResult Create()
        {
            UserViewModel model = new UserViewModel
            {
                Funciones = _combosHelper.GetComboFunciones()
            };
            return View(model);
        }*/
    }

}
