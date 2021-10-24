using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST3.Models
{
    public class tAD
    {
        public string cFirmSN { get; set; }
        public string cADName { get; set; }
        public string cADFileName { get; set; }
        public DateTime cADStartDate { get; set; }
        public DateTime cADDueDate { get; set; }
        public string cADActionDate { get; set; }
        public DateTime cADCreateDate { get; set; }
        public DateTime cADEditDate { get; set; }        
        public bool cADStatus { get; set; }
        public string cADGroup { get; set; }
        public string cADURL { get; set; }
    }
}