using System.ComponentModel.DataAnnotations;

namespace RugbyUnion1.DataTransferObjects
{
    public class TeamDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
        public string Ground { get; set; }
        public string Coach { get; set; }
        public string FoundedYear { get; set; }
        public string Region { get; set; }
    }
}
