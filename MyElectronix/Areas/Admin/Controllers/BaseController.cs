using MyElectronix.Areas.Admin.Models;
using MyElectronix.Models;
using System.Web.Mvc;

namespace MyElectronix.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

    }
}