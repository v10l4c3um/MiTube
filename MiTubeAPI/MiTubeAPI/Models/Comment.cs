using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiTubeModels
{
    public class Comment : Model
    {
        [Required]
        [ForeignKey("FK_User_Id")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("FK_Video_Id")]
        public Guid VideoId { get; set; }
        public virtual Video Video { get; set; }

        public String Value { get; set; }
        public Guid? ParentId { get; set; }

        [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}