using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class Event
    {
        public int ID { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }


        public virtual Image Image { get; set; }

        public int ImageId { get; set; }


        [Required]
        [StringLength(500)]
        public string Description { get; set; }


    }
}