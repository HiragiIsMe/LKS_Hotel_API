using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKS_HOTEL_API.Controllers
{
    public class FDController : ApiController
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HUJGH1E\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True;");
        public DataTable getData(string q)
        {
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        [HttpGet]
        public DataTable get()
        {
            string query = "select ID, Price, Name from FoodsAndDrinks";
            return getData(query);
        }
    }
}
