using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ovn14_Gym.Core.Entities;
using Ovn14_Gym.Core.Repositories;
using Ovn14_Gym.Core.ViewModels;
using Ovn14_Gym.Data.Data;
using Ovn14_Gym.Web.Data;
using Ovn14_Gym.Web.Extensions;
using Ovn14_Gym.Web.Filters;
using Ovn14_Gym.Web.Models;

namespace Ovn14_Gym.Web.Controllers
{
    public class GymClassesController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        //private readonly GymClassRepository gymClassesRepository;

        public GymClassesController(IUnitOfWork uow, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            this.mapper = mapper;
            this.uow = uow;
        }
        [AllowAnonymous]
        // GET: GymClasses
        public async Task<IActionResult> Index()
        {
            var gymClasses = await uow.GymClassRepository.GetWithAttendingAsync();
            var res = mapper.Map<IndexViewModel>(gymClasses);
            return View(res);
        }

      

        public async Task<IActionResult> BookingToggle(int? id)
        {
            if (id is null) return BadRequest();

            var userId = _userManager.GetUserId(User);

            if (userId is null) return NotFound();
            ApplicationUserGymClass? attending = await uow.ApplicationUserGymClassRepository.FindAsync((int)id, userId);

            if (attending == null)
            {
                ApplicationUserGymClass augc = new ApplicationUserGymClass
                {
                    ApplicationUserId = userId,
                    GymClassId = (int)id
                };
                uow.ApplicationUserGymClassRepository.Add(augc);
                await uow.CompleteAsync();
            }
            else
            {
                uow.ApplicationUserGymClassRepository.Remove(attending);
            }

            await uow.CompleteAsync();


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
                await uow.CompleteAsync();
                return Request.IsAjax() ? 
                    PartialView("GymClassPartial", mapper.Map<GymClassViewModel> (gymClass)) 
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
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.GymClasses == null)
        //    {
        //        return NotFound();
        //    }

        //    var gymClass = await _context.GymClasses.FindAsync(id);
        //    if (gymClass == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(gymClass);
        //}

        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        //{
        //    if (id != gymClass.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(gymClass);
        //            uow.CompleteAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!uow.GymClassRepository.GymClassExists(gymClass.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(gymClass);
        //}

        //// GET: GymClasses/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.GymClasses == null)
        //    {
        //        return NotFound();
        //    }

        //    var gymClass = await uow.GymClassRepository.GetAsync((int) id);
        //    if (gymClass == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(gymClass);
        //}

        //// POST: GymClasses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.GymClasses == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.GymClasses'  is null.");
        //    }
        //    GymClass gymClass = await uow.GymClassRepository.FindAsync(id);
        //    //await _context.GymClasses.FindAsync(id);
        //    if (gymClass != null)
        //    {
        //        uow.GymClassRepository.Remove(gymClass);
        //    }

        //    uow.CompleteAsync();
        //    return RedirectToAction(nameof(Index));
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
