using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using WebAPI.Models;

namespace WebAPI.Controllers
{

    public class results { 
        public string DName { get; set; }
        public string DEntity { get; set; }
        public string error { get; set; }
        public results(string DName, string DEntity, string error) {
            this.DName = DName;
            this.DEntity = DEntity;
            this.error = error;
        }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        public List<results> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT * FROM department";

            var results = new List<results>();

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                results.Add(new results(null, null, ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read())
            {
                results.Add(new results(fetch_query["DName"].ToString(), fetch_query["DEntity"].ToString(), null));
            }
            return results;
        }

        // GET api/values/5
        public List<results> Get(string id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "SELECT * FROM department where DName = @id";
            query.Parameters.AddWithValue("@id",id);

            var results = new List<results>();

            try {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex) {
                results.Add(new results(null,null,ex.ToString()));
            }

            MySqlDataReader fetch_query = query.ExecuteReader();

            while (fetch_query.Read()) {
                results.Add(new results(fetch_query["DName"].ToString(), fetch_query["DEntity"].ToString(),null));
            }
            return results;
        }

        //================================================================================================================================

        // POST api/values
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            EmployeePersistence ep = new EmployeePersistence();
            long id;
            id = ep.saveEmployee(value);
            value._empID = id;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, String.Format("values/{0}", id));
            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Employee value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
