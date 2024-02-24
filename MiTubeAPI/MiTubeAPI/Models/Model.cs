using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Model
    {
        [Key]
        public Guid Id { get; set; }
    }
}