using System.ComponentModel.DataAnnotations;

namespace RugbyUnion1.DataTransferObjects
{
    public class PlayerDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string? Name { get; set; }
        public DateTime BirthDay { get; set; }
        public double Height_cm { get; set; }
        public double Weight_kg { get; set; }
        public string? BirthPlace { get; set; }
    }
}
