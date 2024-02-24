using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Playlist : Model
    {
        [Required]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }

        [Required, StringLength(128)]
        public String Name { get; set; }

        virtual public ICollection<Video> Videos { get; set; }
    }
}