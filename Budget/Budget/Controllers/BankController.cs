using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Budget.Controllers
{
    public class BankController : ApiController
    {
        BudgetEntities budegetdbcontext = new BudgetEntities();
        // GET: api/Bank
        public IHttpActionResult Get()
        {
            var data = budegetdbcontext.M_Bank.ToList();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Bank/5
        public IHttpActionResult Get(int id)
        {
            var data = budegetdbcontext.M_Bank.Where(b => b.BankId == id).SingleOrDefault();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Bank
        public IHttpActionResult Post([FromBody]M_Bank bank)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            budegetdbcontext.M_Bank.Add(bank);
            budegetdbcontext.SaveChanges();
            return Ok();
        }

        // PUT: api/Bank/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bank/5
        public void Delete(int id)
        {
        }
    }
}
