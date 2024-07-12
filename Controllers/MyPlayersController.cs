using Microsoft.AspNetCore.Mvc;
using QueJugadorApp.Data;
using QueJugadorApp.Models;
using QueJugadorApp.Models.Entity;

namespace QueJugadorApp.Controllers
{
    public class MyPlayersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public MyPlayersController(ApplicationDbContext DbContext) 
        {
            dbContext = DbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPlayerViewModel ViewModel)
        {
            var Player = new Player()
            {
                PlayerName = ViewModel.PlayerName,
                Age = ViewModel.Age,
                PlayerAddress = ViewModel.PlayerAddress,
                PlayerMail = ViewModel.PlayerMail,
                PlayerPhone = ViewModel.PlayerPhone,
                PlayerPosition = ViewModel.PlayerPosition,
                PlayerGroup = ViewModel.PlayerGroup,
            };
            await dbContext.AddAsync(Player);
            dbContext.SaveChanges();
            return View(); 
        
        }
    }
}
