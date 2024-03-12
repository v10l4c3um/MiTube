using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTubeModels
{
    public class PremiumUser : Model
    {
        [Required]
        [ForeignKey("FK_User_Id")]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }


        [Required]
        public DateTime Date { get; set; } // TODO DateOnly
    }
}