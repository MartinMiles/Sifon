using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Sifon.UK.Website.Model;
using Sifon.UK.Website.Services;

namespace Sifon.UK.Website.Controllers
{
    public class Food
    {
        public string Cook { get; set; }
        public string Meal { get; set; }
    }

    public class FeedbackController : ApiController
    {
        // GET: api/Feedback
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Feedback/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Feedback
        public void Put([FromBody]string value)
        {
        }

        // PUT: api/Feedback/5
        public string Post(/*int id,*/ [FromBody]Feedback f)
        {
            var rootDirectory = HttpContext.Current.Server.MapPath("/");
            var feedbackService = new FeedbackService(rootDirectory);

            try
            {
                var lines = new [] {f.Fullname, f.Email, f.FeedbackMessage};
                feedbackService.SaveToFile(lines);
                return String.Empty;
            }
            catch (Exception e)
            {
                //TODO: Log
                return e.Message;
            }
        }

        // DELETE: api/Feedback/5
        public void Delete(int id)
        {
        }
    }
}
