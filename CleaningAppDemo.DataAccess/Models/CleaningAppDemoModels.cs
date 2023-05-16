using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace CleaningAppDemo.DataAccess.Models
{
    public class CleaningAppDemoModels
    {
        public int AppointmentId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ClientAddress { get; set; }
        public string DestinationAddress { get; set; }

        public const string OriginAddress = "home";
        public DateTime Appointment { get; set; }

        public int EstimatedTimeToComplete { get; set; }
        public int Mileage { get; set; }

        public string Notes { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        public int NumberOfRooms { get; set; }

        //public string SocialMediaPost { get; set; }using fb api

        //public int PicturesOfCompletedTasks { get; set; }store pics in db
        public CleaningAppDemoModels(int appointmentId, string name, string phone, string email, string clientAddress, string destinationAddress, DateTime appointment, int estimatedTimeToComplete, int mileage, string notes, DateTime departureTime, DateTime arrivalTime, int numberOfRooms)
        {
            this.AppointmentId = appointmentId;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.ClientAddress = clientAddress;
            this.DestinationAddress = destinationAddress;
            this.Appointment = appointment;
            this.Notes = notes;
            this.Mileage = mileage;
            this.NumberOfRooms = numberOfRooms;
            this.ArrivalTime = arrivalTime;
            this.DepartureTime = departureTime;
            
        }
        public CleaningAppDemoModels()
        {

        }
    }

}
