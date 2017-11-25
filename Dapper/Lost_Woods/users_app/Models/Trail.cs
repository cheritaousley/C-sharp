using System.ComponentModel.DataAnnotations;

namespace users_app.Models
{
    public class TrailItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public int ElevationGain { get; set; }
        public double Longitude{ get; set; }
        public double Latitude { get; set; }
    }

    public class AddTrailItemViewModel : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Range(10.0, 200.00)]
        public double Length { get; set; }

        [Required]
        [Range(100, 2000)]
        public int ElevationGain { get; set; }

        [Required]
        [Range(0.0, 90.0)]
        public double Longitude { get; set; }

        [Required]
        [Range(0.0, 90.0)]
        public double Latitude { get; set; }
    }
}