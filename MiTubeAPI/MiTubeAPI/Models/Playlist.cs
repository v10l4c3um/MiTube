using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTubeModels
{
    public class Playlist : Model
    {
        [Required]
        [ForeignKey("FK_User_Id")]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }

        [Required, StringLength(128)]
        public String Name { get; set; }

        virtual public ICollection<Video> Videos { get; set; }
    }
}