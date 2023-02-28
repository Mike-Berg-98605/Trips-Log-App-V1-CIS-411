using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TripsLogApp.Models
{
    public class TripDetail
    {
        // EF will instruct the database to automatically generate this value
        public int TripDetailID { get; set; }
        
        [Required(ErrorMessage = "Please Enter a Destination")]    
        public string Destination { get; set; }
       
        public string Accomodations { get; set; }

        [Required(ErrorMessage = "Please Enter a start date")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a valid date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please Enter a valid date")]
        [Required(ErrorMessage = "Please Enter an end start date")]
        public DateTime EndDate { get; set; }

       
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number must be valid.")]
        public string PhoneNumber { get; set; }
        
        [DataType(DataType.EmailAddress, ErrorMessage = "Email must be valid.")]
        public string Email { get; set; }       
        public string FirstThingToDo { get; set; }        
        public string SecondThingToDo { get; set; }        
        public string ThirdThingToDo { get; set; }

        public string Slug =>
            Destination?.Replace(' ', '-').ToLower() + '-' + Accomodations?.Replace(' ', '-').ToLower();
    }
}

