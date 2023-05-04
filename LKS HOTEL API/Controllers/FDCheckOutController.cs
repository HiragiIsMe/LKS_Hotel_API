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
        HotelEntities1 ent = new HotelEntities1();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HUJGH1E\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True;");
        private int IdReser;
        [HttpPost]
        public IHttpActionResult post(FDCheckOutModel fd)
        {
            SqlCommand cmd = new SqlCommand("select top(1) id from reservationRoom where roomId = " + fd.RoomID + " order by id desc", conn);
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
                ResponseModel responseModel = new ResponseModel();
                responseModel.Status = 1;

                return Ok(responseModel);
            }catch(Exception ex)
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.Status = 0;
                return Ok(responseModel);
            }
        }
    }
}
