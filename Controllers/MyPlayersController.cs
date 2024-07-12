using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (ModelState.IsValid)
            {
                var player = new Player
                {
                    PlayerName = ViewModel.PlayerName,
                    Age = ViewModel.Age,
                    PlayerAddress = ViewModel.PlayerAddress,
                    PlayerMail = ViewModel.PlayerMail,
                    PlayerPhone = ViewModel.PlayerPhone,
                    PlayerPosition = ViewModel.PlayerPosition,
                    PlayerGroup = ViewModel.PlayerGroup
                };

                await dbContext.MyPlayers.AddAsync(player);
                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); // Redirect to home page after successful addition
            }

            return View(ViewModel); // Return the view with validation errors
        }
        // To add list functionality
        [HttpGet]
        public async Task <IActionResult> List(AddPlayerViewModel ViewModel)
        {
           var Players = await dbContext.MyPlayers.ToListAsync();
            return View(Players);
        }
    }
}
