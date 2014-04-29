using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public abstract class Address
    {
        #region
       
        public string Residence { get; set; }
        public string Parish { get; set; }
        public string Division { get; set; }

        //public virtual District District { get; set; }
        #endregion
    }
}