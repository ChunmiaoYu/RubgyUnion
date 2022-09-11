using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyUnion1.Models
{
    [Table("Player")]
    public class Player
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string? Name { get; set; }
        public DateTime BirthDay { get; set; }
        public double Height_cm { get; set; }
        public double Weight_kg { get; set; }
        public string BirthPlace { get; set; }
        //public string Name { get; set; }
        [ForeignKey(nameof(Team))]
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }

        public Player()
        {
            Id = Guid.NewGuid();
        }
        public Player(Guid id)
        {
            Id = id;
        }
    }
}