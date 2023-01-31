using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ovn14_Gym.Core.Entities;
using Ovn14_Gym.Data.Data;
using Ovn14_Gym.Data.Repositories;
using Ovn14_Gym.Web.Data;
using Ovn14_Gym.Web.Extensions;
using Ovn14_Gym.Web.Filters;
using Ovn14_Gym.Web.Models;

namespace Ovn14_Gym.Web.Controllers
{
    public class GymClassesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork uow;

        //private readonly GymClassRepository gymClassesRepository;

        public GymClassesController(IUnitOfWork uow, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
          //  gymClassesRepository = new GymClassRepository(context);
          this.uow = uow;
        }
        [AllowAnonymous]
        // GET: GymClasses
        public async Task<IActionResult> Index()
        {
            List<GymClass> model = await uow.GymClassRepository.GetAsync();
 
            return View(model);
        }

      

        //[Authorize]
        public async Task<IActionResult> BookingToggle(int? id)
        {
            if (id is null) return BadRequest();

            var userId = _userManager.GetUserId(User);

            if (userId is null) return NotFound();
            ApplicationUserGymClass? attending = await uow.ApplicationUserGymClassRepository.FindAsync((int)id, userId);

            if (attending == null)
            {
                var augc = new ApplicationUserGymClass
                {
                    ApllicationUserId = userId,
                    GymClassId = (int)id
                };
                // _context.AppUserGymClass.Add(augc);
                uow.ApplicationUserGymClassRepository.Add(augc);
            }
            else
            {
                uow.ApplicationUserGymClassRepository.Remove(attending);
            }

            uow.CompleteAsync();


            return RedirectToAction("Index");
        }



        // GET: GymClasses/Details/5
        [RequiredParameterRequiredModel("id")]
        public async Task<IActionResult> Details(int? id)
        {
            return View(await uow.GymClassRepository.GetAsync((int)id));
        }

        // GET: GymClasses/Create
        public IActionResult Create()
        {
            return Request.IsAjax() ? PartialView("CreatePartial"): View();
        }


        public IActionResult FetchForm()
        {
            return PartialView("CreatePartial");
        }



        // POST: GymClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                uow.GymClassRepository.Add(gymClass);
                uow.CompleteAsync();
                return Request.IsAjax() ? 
                    PartialView("GymClassPartial", gymClass) 
                    : RedirectToAction(nameof(Index));
            }

            if (Request.IsAjax())
            {

                Response.StatusCode = StatusCodes.Status400BadRequest;

                return PartialView("CreatePartial", gymClass);
            }

            return View(gymClass);
        }




        // GET: GymClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GymClasses == null)
            {
                return NotFound();
            }

            var gymClass = await _context.GymClasses.FindAsync(id);
            if (gymClass == null)
            {
                return NotFound();
            }
            return View(gymClass);
        }

        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        {
            if (id != gymClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gymClass);
                    uow.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!uow.GymClassRepository.GymClassExists(gymClass.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gymClass);
        }

        // GET: GymClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GymClasses == null)
            {
                return NotFound();
            }

            var gymClass = await uow.GymClassRepository.GetAsync((int) id);
            if (gymClass == null)
            {
                return NotFound();
            }

            return View(gymClass);
        }

        // POST: GymClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GymClasses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GymClasses'  is null.");
            }
            GymClass gymClass = await uow.GymClassRepository.FindAsync(id);
            //await _context.GymClasses.FindAsync(id);
            if (gymClass != null)
            {
                uow.GymClassRepository.Remove(gymClass);
            }

            uow.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
