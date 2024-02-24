using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class PremiumUser : Model
    {
        [Required]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }


        [Required]
        public DateTime Date { get; set; } // TODO DateOnly
    }
}