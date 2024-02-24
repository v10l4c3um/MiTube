using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class User : Model
    {
        [Required]
        public int UserTypeId { get; set; }
        virtual public UserType UserType { get; set; }

        [Required, StringLength(64)]
        public String Name { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public Guid PremiumUserId;
        virtual public PremiumUser PremiumUser { get; set; } // ???

        virtual public ICollection<Comment> Comments { get; set; }
        virtual public ICollection<Like> Likes { get; set; }
    }
}