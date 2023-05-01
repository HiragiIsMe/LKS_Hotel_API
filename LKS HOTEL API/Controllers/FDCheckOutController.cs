using LKS_HOTEL_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKS_HOTEL_API.Controllers
{
    public class FDCheckOutController : ApiController
    {
        HotelEntities ent = new HotelEntities();
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-S8UCE514;Initial Catalog=Hotel;Integrated Security=True;");
        private int IdReser;
        [HttpPost]
        public bool post(FDCheckout fd)
        {
            SqlCommand cmd = new SqlCommand("select top(1) id from reservationRoom where roomId = " + fd.ReservationRoomID + " order by id desc", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            IdReser = reader.GetInt32(0);
            conn.Close();

            SqlCommand cmd1 = new SqlCommand("insert into FDCheckout values("+ IdReser +", "+ fd.FDID +", "+ fd.Qty +", "+ fd.TotalPrice +", "+ fd.EmployeeID +")",conn);
            conn.Open();
            try
            {
                cmd1.ExecuteNonQuery();
                conn.Close();
                return true;
            }catch(Exception ex)
            {
                conn.Close();
                return false;
            }
        }
    }
}
