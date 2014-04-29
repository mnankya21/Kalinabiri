using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class BaseEntity
    {
        #region base entity properties

        
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        
        #endregion
    }
}