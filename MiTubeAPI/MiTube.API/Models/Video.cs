using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTubeModels
{
    public class Video : Model
    {
        [Required]
        [ForeignKey("FK_User_Id")]
        public Guid UserId { get; set; }

        [Required, StringLength(64)]
        public String Title { get; set; }

        [Required]
        public String VideoUrl { get; set; }
        [Required]
        public String PosterUrl { get; set; }

        public int Likecount { get; set; }

        [StringLength(1024)]
        public String Description { get; set; }

        virtual public ICollection<Tag> Tags { get; set; }
        virtual public ICollection<Comment> Comments { get; set; }
        virtual public ICollection<Like> Likes { get; set; }
        virtual public ICollection<Playlist> Playlists { get; set; }

    }
}