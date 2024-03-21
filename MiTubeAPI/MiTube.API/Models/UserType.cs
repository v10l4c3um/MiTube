using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Description { get; set; }
    }
}