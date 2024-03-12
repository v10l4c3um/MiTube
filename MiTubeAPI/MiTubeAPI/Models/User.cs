using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTubeModels
{
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User : Model
    {
        [Required]
        [ForeignKey("FK_UserType_Id")]
        public int UserTypeId { get; set; }
        virtual public UserType UserType { get; set; }

        [Required, StringLength(64)]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        virtual public ICollection<Like> Likes { get; set; }
    }
}