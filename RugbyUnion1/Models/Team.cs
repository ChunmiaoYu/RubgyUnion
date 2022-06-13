using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyClub1.Models
{
    [Table("Team")]
    public class Team
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }
        public string Ground { get; set; }
        public string Coach { get; set; }
        public string FoundedYear { get; set; }
        public string Region { get; set; }

        public virtual ICollection<Player>? Players { get; set; }

        public Team()
        {
            Id = Guid.NewGuid();
        }
        public Team(Guid id)
        {
            Id = id;
        }
    }
}