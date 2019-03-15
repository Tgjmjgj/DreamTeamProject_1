using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Constants;
using Unosquare.Labs.EmbedIO.Modules;

namespace DreamTeamProject
{
    public class AccountController : WebApiController
    {
        IHttpContext _context;
        public AccountController(IHttpContext context) : base(context)
        {
            _context = context;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/users/{id}")]
        public bool GetUserById(int id)
        {
            try
            {
                if (People.Users.Any(p => p.Id == id))
                {
                    return this.JsonResponse(People.Users.FirstOrDefault(p => p.Id == id));
                }
            }
            catch (Exception ex)
            {
                return this.JsonExceptionResponse(ex);
            }
            return false;
        }

        [WebApiHandler(HttpVerbs.Get, "/api/users")]
        public bool GetUsers()
        {
            try
            {
                return this.JsonResponse(People.Users);
            }
            catch (Exception ex)
            {
                return this.JsonExceptionResponse(ex);
            }
        }

        // You can override the default headers and add custom headers to each API Response.
        public override void SetDefaultHeaders() => this.NoCache();

        [WebApiHandler(HttpVerbs.Post, "/api/users")]
        public bool PostUser()
        {
            try
            {
                var data = this.RequestFormDataDictionary();
                User user = new User();
                user.Id = Convert.ToInt32(data.Values.ElementAt(0));
                user.FirstName = Convert.ToString(data.Values.ElementAt(1));
                user.SecondName = Convert.ToString(data.Values.ElementAt(2));
                user.Mail = Convert.ToString(data.Values.ElementAt(3));
                user.Phone = Convert.ToString(data.Values.ElementAt(4));
                user.Password = Convert.ToString(data.Values.ElementAt(5));
                user.ConfirmedPassword = Convert.ToString(data.Values.ElementAt(6));

                People.Users.Add(user);
                return true;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebApiHandler(HttpVerbs.Delete, "/api/user/{id}")]
        public void RemoveUser(int? id)
        {
            if (id != null)
            {
                User user = People.Users.Where(u => u.Id == id).FirstOrDefault();
                if(user != null)
                    People.Users.Remove(user);
            }
        }
    }
}
