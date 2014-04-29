using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class District
    {
        #region Base District
        [Key]
        public int DistrictID { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        #endregion
        #region NAvigation properties for Districts

        public virtual List<Parent> Parents { get; set; }
        public virtual List<NextOfKin> NextOfKins { get; set; }
        public virtual List<Pupil> Pupils { get; set; }
        public virtual List<Teacher> Teachers { get; set; }

        public District() {

            Parents = new List<Parent>();
            NextOfKins = new List<NextOfKin>();
            Pupils = new List<Pupil>();
            Teachers = new List<Teacher>();
        }

        public static List<District> getDistricts()
        {
            using (Repository repo = new Repository())
            {

                return (repo.Districts.ToList());
            }

        }

        #endregion
    }
}