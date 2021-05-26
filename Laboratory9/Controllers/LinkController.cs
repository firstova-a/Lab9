using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Laboratory9.Entities;
using Laboratory9.Models;

namespace Laboratory9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private LinkContext context = new LinkContext();
        [HttpGet]
        public IEnumerable<LinkModel> Get(string username, string password)
        {
            UserInfo sender = context.Users.SingleOrDefault(usr => usr.Username == username);
            if (sender != null && Crypto.VerifyHashedPassword(sender.PasswordHash, password))
            {
                IQueryable<LinkDes> allMesages = from msg in context.Links
                                                 orderby msg.Id
                                                 select msg;
                return allMesages.ToList().ConvertAll(msg => LinkModel.FromEntity(msg));
            }
            else
            {
                return null;
            }
        }
    }
}
