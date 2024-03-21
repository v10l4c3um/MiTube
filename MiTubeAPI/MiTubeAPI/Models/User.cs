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
        

        [Required, StringLength(64)]
        public String Name { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }
        
        //properties navigation
        public virtual UserType? UserType { get; set; }

        public virtual ICollection<Like>? Likes { get; set; }
        public virtual ICollection<Subscription>? Subscriptions { get; set; }
    }
}