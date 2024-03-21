using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiTubeModels
{
    public class Like : Model
    {
        [Required]
        [ForeignKey("FK_User_Id")]
        public Guid UserId { get; set; }
        virtual public User User { get; set; }

        [Required]
        [ForeignKey("FK_Video_Id")]
        public Guid VideoId { get; set; }

        [Required]
        public bool IsLike { get; set; }
    }
}