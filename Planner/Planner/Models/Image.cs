using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

    }
}