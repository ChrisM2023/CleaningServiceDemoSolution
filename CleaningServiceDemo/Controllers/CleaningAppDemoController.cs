using CleaningAppDemo.DataAccess.Context;
using CleaningAppDemo.DataAccess.Models;
using CleaningServiceDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningServiceDemo.Controllers
{
    public class CleaningAppDemoController : Controller
    {
        private readonly CleaningAppDemoDbContext _context;

        public CleaningAppDemoController(CleaningAppDemoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CleaningAppDemoViewModel model = new CleaningAppDemoViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int appointmentId, string name, string phone, string email, string clientAddress, string destinationAddress, DateTime appointment, int estimatedTimeToComplete, int mileage, string notes, DateTime departureTime, DateTime arrivalTime, int numberOfRooms)
        {
            CleaningAppDemoViewModel model = new CleaningAppDemoViewModel(_context);

            CleaningAppDemoModels cleaningAppDemo = new (appointmentId, name, phone, email, clientAddress, destinationAddress, appointment, estimatedTimeToComplete, mileage, notes, departureTime, arrivalTime, numberOfRooms);

            model.SaveAppointment(cleaningAppDemo);
            model.IsActionSuccess = true;
            model.ActionMessage = "Appointment has been saved successfully";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            CleaningAppDemoViewModel model = new CleaningAppDemoViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            CleaningAppDemoViewModel model = new CleaningAppDemoViewModel(_context);

            if (id > 0)
            {
                model.RemoveAppoinment(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Appoinment has been deleted successfully";
            return View("Index", model);
        }
    } 
}
