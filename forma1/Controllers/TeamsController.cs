using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forma1.Data;
using forma1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forma1.Controllers
{
    public class TeamsController : Controller
    {

        private Forma1DbContext DbContext;
        private SignInManager<User> signInManager;

        public TeamsController(Forma1DbContext context, SignInManager<User> signInManager)
        {
            DbContext = context;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await DbContext.Teams.ToListAsync());
        }

        public async Task<IActionResult> Delete(long id)
        {
            if (!signInManager.IsSignedIn(User))
                return RedirectToAction("Index");

            Team teamToDelete = DbContext.Teams.Find(id);
            if (teamToDelete != null)
            {
                DbContext.Teams.Remove(teamToDelete);
                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            if (!signInManager.IsSignedIn(User))
                return RedirectToAction("Index");

            Team teamToEdit = DbContext.Teams.Find(id);
            return View(teamToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Team team)
        {
            if (!signInManager.IsSignedIn(User))
                return RedirectToAction("Index");

            Team originalTeam = DbContext.Teams.Find(team.ID);

            originalTeam.Name = team.Name;
            originalTeam.YearFounded = team.YearFounded;
            originalTeam.WorldChampionshipsWon = team.WorldChampionshipsWon;
            originalTeam.PaidEntryFee = team.PaidEntryFee;

            await DbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!signInManager.IsSignedIn(User))
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            if (!signInManager.IsSignedIn(User))
                return RedirectToAction("Index");

            DbContext.Teams.Add(team);
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
