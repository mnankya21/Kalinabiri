using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalinabiri.Models
{
    public class NextOfKin : Address
    {
        #region Next Of Kin Properties

        [Key]
        public int NextOfKinID { get; set; }
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string PlaceOfWork { get; set; }
        public string TelephoneNumber { get; set; }

        #endregion
        public virtual List<Pupil> pupil { get; set; }
        public virtual District District { get; set; }

        public NextOfKin()
        {

            pupil = new List<Pupil>();

        }

        public static List<NextOfKin> GetNextOfKeens()
        {

            using (Repository repo = new Repository())
            {

                return (repo.NextOfKin.ToList());
            }


        }
    }
}