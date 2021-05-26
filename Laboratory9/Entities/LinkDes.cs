using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratory9.Entities
{
    public class LinkDes
    {
        public int Id { get; set; }
        public virtual UserInfo Sender { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
