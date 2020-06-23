using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Budget.Models;

namespace Budget.Controllers
{
    [RoutePrefix("api/registration")]
    public class RegistrationController : ApiController
    {
        BudgetEntities budegetdbcontext=new BudgetEntities();
        [HttpGet]
        [Route("users")]
        public IHttpActionResult users()
        {
            var data = budegetdbcontext.M_UserRegistration.ToList();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
            //return
        }

        // GET: api/Registration/5
        public IHttpActionResult Get(int id)
        {
            var data = budegetdbcontext.M_UserRegistration.Where(u => u.UserId == id).SingleOrDefault();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }            
        }

        // POST: api/Registration
        public IHttpActionResult Post([FromBody]M_UserRegistration user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            budegetdbcontext.M_UserRegistration.Add(user);
            budegetdbcontext.SaveChanges();
            return Ok();
        }
        [Route("UpdateDetails")]
        // PUT: api/Registration/5
        public IHttpActionResult Put(int id, [FromBody]M_UserRegistration user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var data = (from u in budegetdbcontext.M_UserRegistration where u.UserId == id select u).ToList();
            budegetdbcontext.SaveChanges();
            return Ok();
        }

        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
    }
}
