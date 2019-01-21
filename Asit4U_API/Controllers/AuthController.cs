using Asit4U_API.BLL;
using Asit4U_API.DataAccess;
using Asit4U_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Asit4U_API.Controllers
{

    public class AuthController : ApiController
    {
        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        //GET: api/Users/5
        [System.Web.Mvc.HttpPost]
        public JsonResult Login([FromBody]LoginModel model)
        {
            if (model.Username == null || model.Password == null)
            {
                model.Message = "Please enter a username and password";
            }
            else
            {
                DataHandler handler = new DataHandler();
                User user = handler.SelecUser(model.Username);

                if (user.Password == model.Password)
                {
                    model.Message = "You have succesfully logged in";
                }
                else
                {
                    model.Message = "Your username or password was Incorrect";
                }

            }

            JsonResult result = new JsonResult
            {
                Data = model
            };

            return result;

        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}
