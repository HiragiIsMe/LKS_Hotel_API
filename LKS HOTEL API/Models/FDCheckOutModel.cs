﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LKS_HOTEL_API.Models
{
    public class FDCheckOutModel
    {
        public int RoomID { set; get; }
        public int FDID { set; get; }
        public int Qty { set; get; }
        public int TotalPrice { set; get; }
        public int EmployeeID { set; get; }
    }
}