using System;
using System.ComponentModel.DataAnnotations;

namespace MiTubeModels
{
    public class Subscription : Model
    {
        [Required]
        public Guid SubscriberId { get; set; }
        public Guid PublisherId { get; set; }
        virtual public User Subscriber { get; set; }
        virtual public User Publisher { get; set; }
    }
}