﻿using Microsoft.AspNetCore.Mvc;
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

                return RedirectToAction("List", "MyPlayers"); // Redirect to List page after successful addition
            }

            return View(ViewModel); // Return the view with validation errors
        }

        // To add list functionality
/*        [HttpGet]
        public async Task<IActionResult> List(AddPlayerViewModel ViewModel)
        {
            var Players = await dbContext.MyPlayers.ToListAsync();
            return View(Players);
        }*/

        // View List + sorting Age
        [HttpGet]
        public async Task<IActionResult>List(string sortOrder) 
        {
            var Players = await dbContext.MyPlayers.ToListAsync();

            switch(sortOrder)
            {
                case "asc":
                    Players = Players.OrderBy(p => p.Age).ToList();
                    break;
                case "desc":
                    Players = Players.OrderByDescending(p => p.Age).ToList();
                    break;
                default:
                    break; // Dont have to sort

            }
            return View(Players);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var Player = await dbContext.MyPlayers.FindAsync(Id);
            return View(Player);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Player ViewModel)
        {
            if (ModelState.IsValid)
            {
                var Player = await dbContext.MyPlayers.FindAsync(ViewModel.Id);
                if (Player != null)
                {
                    Player.PlayerName = ViewModel.PlayerName;
                    Player.Age = ViewModel.Age;
                    Player.PlayerAddress = ViewModel.PlayerAddress;
                    Player.PlayerMail = ViewModel.PlayerMail;
                    Player.PlayerPhone = ViewModel.PlayerPhone;
                    Player.PlayerPosition = ViewModel.PlayerPosition;
                    Player.PlayerGroup = ViewModel.PlayerGroup;

                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("List", "MyPlayers");
                }
            }
            return View(ViewModel); // Return the view with validation errors
        }

        [HttpPost]
        public async Task <IActionResult> Delete(Player ViewModel)
        {
            var Player = await dbContext.MyPlayers.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==ViewModel.Id);
            if (Player != null)
            {
                dbContext.MyPlayers.Remove(ViewModel);
                await dbContext.SaveChangesAsync();

            }
            return RedirectToAction("List", "MyPlayers");
        }
    }
}
