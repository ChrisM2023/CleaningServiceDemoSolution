using System.Collections.Generic;
using CleaningServiceDemo.Models;
using CleaningServiceDemo.Controllers;
using System.Linq;
using System;
using Microsoft.Identity.Client;
using CleaningAppDemo.DataAccess.Models;
using CleaningAppDemo.DataAccess.Context;
using CleaningAppDemo.DataAccess.Repositories;

namespace CleaningServiceDemo.Models
{
    public class CleaningAppDemoViewModel
    {
        private readonly CleaningAppDemoRepository _configuration;
     
        public List<CleaningAppDemoModels> CleaningAppDemosList { get; set; }
        public CleaningAppDemoModels CurrentCleaningAppDemo { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }
       
        public CleaningAppDemoViewModel(CleaningAppDemoDbContext configuration)
        {
            _configuration = new CleaningAppDemoRepository(configuration);
            CleaningAppDemosList = GetAllCleaningAppDemo();
            CurrentCleaningAppDemo = CleaningAppDemosList.FirstOrDefault();
        }
       
        public CleaningAppDemoViewModel(CleaningAppDemoDbContext configuration,int AppointMentId)
        {
            _configuration = new CleaningAppDemoRepository(configuration) ;
            CleaningAppDemosList = new List<CleaningAppDemoModels>();

            if(AppointMentId > 0)
            {
                CurrentCleaningAppDemo = GetCleaningAppDemo(AppointMentId);

            }
            else
            {
                CurrentCleaningAppDemo = new CleaningAppDemoModels();
            }
           

        }
        
        public void SaveAppointment(CleaningAppDemoModels models)
        {
            if(models.AppointmentId > 0)
            {
                _configuration.Update(models);
            }
            else
            {
                models.AppointmentId = _configuration.Create(models);
            }
            CleaningAppDemosList = GetAllCleaningAppDemo();
            CurrentCleaningAppDemo = GetCleaningAppDemo(models.AppointmentId);
        }
        public void RemoveAppoinment(int id)
        {
            _configuration.Delete(id);
            CleaningAppDemosList = GetAllCleaningAppDemo();
            CurrentCleaningAppDemo = CleaningAppDemosList.FirstOrDefault();
        }
        public List<CleaningAppDemoModels> GetAllCleaningAppDemo()
        {
            return _configuration.GetAllAppointments();

        }
        public CleaningAppDemoModels GetCleaningAppDemo(int AppointMentId)
        {
            return _configuration.GetAppointmentByID(AppointMentId);
        }
    }
}
