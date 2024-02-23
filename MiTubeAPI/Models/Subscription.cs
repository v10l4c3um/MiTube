using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Subscription : Model
    {
        [Required]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }
    }
}