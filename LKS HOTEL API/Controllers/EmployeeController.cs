using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using LKS_HOTEL_API.Models;
namespace LKS_HOTEL_API.Controllers
{
    public class EmployeeController : ApiController
    {
        HotelEntities ent = new HotelEntities();

        string encrypt(string s)
        {
            using (SHA256Managed managed = new SHA256Managed())
            {
                byte[] b = managed.ComputeHash(Encoding.UTF8.GetBytes(s));
                return Convert.ToBase64String(b);
            }
        }

        [HttpPost]
        public IHttpActionResult post(Employee emp)
        {
            string sql = "select * from employee where username = '" + emp.Username + "' and password = '" + encrypt(emp.Password) + "'";
            var user = ent.Employees.SqlQuery(sql).FirstOrDefault();
            if (user != null)
            {
                EmployeeModel e = new EmployeeModel();
                e.id = user.ID;
                e.name = user.Name;
                e.username = user.Username;

                return Ok(e);
            }

            return null;
        }
    }
}
