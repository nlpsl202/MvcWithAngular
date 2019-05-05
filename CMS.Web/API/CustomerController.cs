using CMS.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.Web.API
{
    public class CustomerController : ApiController
    {
        private CustomerService service;

        private CustomerController()
        {
            service = new CustomerService();
        }

        // GET: api/Empty
        [HttpGet]
        public HttpResponseMessage Customers(int CurrPage,int PageSize)
        {
            try
            {
                int TotalRow = 0;
                var datas = service.Get(CurrPage,PageSize,out TotalRow);
                var Rvl = new { Total = TotalRow, Data = datas };
                return Request.CreateResponse(HttpStatusCode.OK, Rvl);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }

        // GET: api/Empty/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empty
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empty/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empty/5
        public void Delete(int id)
        {
        }
    }
}
