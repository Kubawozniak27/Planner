using Planner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Planner.ViewModels
{
    public class EventFormViewModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public int  Category{ get; set; }

        public IEnumerable<Category> Categories { get; set; }


     

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}