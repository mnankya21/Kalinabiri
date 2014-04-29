using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class SupportStaff:Address
    {
        #region Support Staff Properties
        [Key]
        public int SupportStaffID { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public byte[] Photo { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string JobDescription { get; set; }

        #endregion
    }
}