using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratory9.Entities;

namespace Laboratory9.Models
{
    public class LinkModel
    {
        public string Sender { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public static LinkModel FromEntity(LinkDes msg)
        {
            return new LinkModel()
            {
                Sender = msg.Sender.Username,
                Link = msg.Link,
                Description = msg.Description
            };
        }
    }
}
