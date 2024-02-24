using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Poster : Model
    {
        [Required]
        public Guid VideoId { get; set; }
        virtual public Video Video { get; set; }

        [Required]
        public String Name { get; set; } // ???

        [Required]
        public String Url { get; set; }
    }
}

