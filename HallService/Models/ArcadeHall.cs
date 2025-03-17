using System.ComponentModel.DataAnnotations;

namespace HallService.Models
{
    public class ArcadeHall
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        
    }
}
