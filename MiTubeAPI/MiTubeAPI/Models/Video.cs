using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Video : Model
    {
        [Required]
        public Guid UserId { get; set; }

        [Required, StringLength(64)]
        public String Title { get; set; }

        [Required]
        public String Url { get; set; }

        public int Likecount { get; set; }

        [Required]
        public String PosterUrl { get; set; }

        [StringLength(1024)]
        public String Description { get; set; }

        virtual public ICollection<Tag> Tags { get; set; }
        virtual public ICollection<Comment> Comments { get; set; }
        virtual public ICollection<Like> Likes { get; set; }

    }
}