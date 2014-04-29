using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalinabiri.Models
{
    public class Pupil:Address
    {
        #region Pupil Properties

        [Key]
        public int PupilID { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public byte[] Photo { get; set; }
        public string Gender { get; set; }
        public string PupilClass { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEntry { get; set; }
        public string Stream { get; set; }
        public string TypeOfPupil { get; set; }
        public string Religion{ get; set; }
        public string HealthProblem { get; set; }
        public string ContentType { get; set; }
        [ForeignKey("District")]
        public int DistrictID{ get; set; }
        [ForeignKey("House")]
        public int HouseID { get; set; }
        [ForeignKey("parent")]
        public int ParentID { get; set; }
        [ForeignKey("nextOfKin")]
        public int? NextOfKinID { get; set; }
        #endregion

        #region Navigation properties for pupil

        public virtual Parent parent { get; set; }
        public virtual NextOfKin nextOfKin { get; set; }
        public virtual District District { get; set; }
        public virtual House House { get; set; }
      
        #endregion
    }
}