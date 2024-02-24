using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class PremiumUser : Model
    {
        [Required] //??
        public Guid UserId { get; set; }
        virtual public User User { get; set; }
        virtual public ICollection<User> Users { get; set; }
        // ??


        [Required]
        public String Description { get; set; } // ???
    }
}