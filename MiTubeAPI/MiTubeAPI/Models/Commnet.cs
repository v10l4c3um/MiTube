using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MiTubeModels
{
    public class Comment : Model
    {
        [Required]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public Guid VideoId { get; set; }
        public virtual Video Video { get; set; }

        public string? Value { get; set; }
        public Guid? ParentId { get; set; }

        [Timestamp]
        public DateTime Timestamp { get; set; }
    }
}