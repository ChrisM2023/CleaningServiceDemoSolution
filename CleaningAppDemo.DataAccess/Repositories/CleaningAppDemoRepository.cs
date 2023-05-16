using CleaningAppDemo.DataAccess.Context;
using CleaningAppDemo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningAppDemo.DataAccess.Repositories
{
    public class CleaningAppDemoRepository
    {
        private readonly CleaningAppDemoDbContext _context;
        public CleaningAppDemoRepository(CleaningAppDemoDbContext context)
        {
            _context = context;
        }
        public int Create(CleaningAppDemoModels cleaningAppDemoModels)
        {
            _context.Add(cleaningAppDemoModels);
            _context.SaveChanges();
            return cleaningAppDemoModels.AppointmentId;
        }
        public void Update(CleaningAppDemoModels cleaningAppDemoModels)
        {
            CleaningAppDemoModels existingAppointment = _context.CleaningAppDemoModels.Find(cleaningAppDemoModels.AppointmentId);
            existingAppointment.Name = cleaningAppDemoModels.Name;
            existingAppointment.Phone = cleaningAppDemoModels.Phone;
            existingAppointment.Email = cleaningAppDemoModels.Email;
            existingAppointment.ClientAddress = cleaningAppDemoModels.ClientAddress;
            existingAppointment.DestinationAddress = cleaningAppDemoModels.DestinationAddress;
            existingAppointment.Appointment = cleaningAppDemoModels.Appointment;
            existingAppointment.EstimatedTimeToComplete = cleaningAppDemoModels.EstimatedTimeToComplete;
            existingAppointment.Mileage = cleaningAppDemoModels.Mileage;
            existingAppointment.Notes = cleaningAppDemoModels.Notes;
            existingAppointment.DepartureTime = cleaningAppDemoModels.DepartureTime;
            existingAppointment.NumberOfRooms = cleaningAppDemoModels.NumberOfRooms;
            _context.SaveChanges();
        }
        public void Delete(int appointmentId)
        {
            CleaningAppDemoModels existingAppointment = _context.CleaningAppDemoModels.Find(appointmentId);
            _context.Remove(existingAppointment);
            _context.SaveChanges();

        }
        public List<CleaningAppDemoModels> GetAllAppointments()
        {
            return _context.CleaningAppDemoModels.ToList();
        }
        public CleaningAppDemoModels GetAppointmentByID(int id)
        {
            return _context.CleaningAppDemoModels.Find(id);
        }
    }
}
