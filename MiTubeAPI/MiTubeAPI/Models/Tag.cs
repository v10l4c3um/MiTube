using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Tag : Model
    {
        [Required, StringLength(64)]
        public String Name { get; set; }

        virtual public ICollection<Video> Videos { get; set; }
    }
}