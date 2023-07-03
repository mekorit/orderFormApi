using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {


        // GET: api/Users
        //  [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("SendMailJsonData")]
        public bool SendMailJsonData([FromBody] DataFromJson dataOrder)
        {
            bool res = false;
            if (IsValidEmail(dataOrder.mail)) { 
                res = OrdersManager.Send(dataOrder.mail, "מקורית- הפריטים שהוזמנו", dataOrder.tableItemsOrdered, "", "", "", "", null, "", "", "mhazmanot38@gmail.com", "rzrcoaqrseeeittj");
        }
            if (res)
            {
                res = OrdersManager.Send("mhazmanot38@gmail.com", "MekoritOrderForm_From_Website", JsonConvert.SerializeObject(dataOrder), "", "", "", "", null, "", "", "mhazmanot38@gmail.com", "rzrcoaqrseeeittj");
            }
            return res;
        }

        bool IsValidEmail(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);

        }


    }
}
