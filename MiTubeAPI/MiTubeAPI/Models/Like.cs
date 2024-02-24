using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Like : Model
    {
        [Required]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }

        [Required]
        public Guid VideoId { get; set; }

        [Required]
        public bool IsLike { get; set; }
    }
}