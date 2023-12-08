using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Domains.Soccer;

namespace OneBackComboTrainingWeb.Controllers
{
    public class MatchController : Controller
    {
        private readonly SoccerRepo _soccerRepo;
        public MatchController()
        {
            _soccerRepo = new SoccerRepo();
        }

        public IActionResult Index()
        {
            var soccerGameService = new SoccerGameService(_soccerRepo);
            return View();
        }
    }
}
