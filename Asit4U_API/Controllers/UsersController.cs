using Asit4U_API.BLL;
using Asit4U_API.DataAccess;
using Asit4U_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Asit4U_API.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        [System.Web.Mvc.HttpGet]
        public JsonResult Get()
        {
            DataHandler handler = new DataHandler();
            List<User> users = handler.SelecAllUser();

            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = users
            };

            return result;
        }



        // POST: api/Users
        [System.Web.Mvc.HttpPost]
        public JsonResult Register([FromBody]RegisterModel model)
        {

            JsonResult result = new JsonResult();

            if (model.Password != model.ConfirmPassword)
            {
                model.Message = "Please make sure that your passwords match";
                
            }
            else if (model.Username == null || model.Password == null)
            {
                model.Message = "Please make sure that all fields are filled in";

            }
            else
            {
                DataHandler handler = new DataHandler();

                User u = new User
                {
                    Username = model.Username,
                    Password = model.Password

                };

                handler.InsertUser(u);

                model.Message = "You have registered succesfully";

            }

            result = new JsonResult
            {
                Data = model
            };

            return result;
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
