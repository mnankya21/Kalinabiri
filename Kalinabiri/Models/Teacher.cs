using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class Teacher:Address
    {
        #region Teachers Properties

        [Key]
        public int TeacherID { get; set; }

        [ForeignKey("House")]
        public int HouseID { get; set; }
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public byte[] Photo { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string TelephoneNo { get; set; }

        #endregion

        #region Navigation properties for Teacher

        public virtual List<SubjectAndTeacher> SubjectAndTeacherMappings { get; set; }
        public virtual House House { get; set; }
        public virtual District District { get; set; }

        #endregion

        public Teacher() {

            SubjectAndTeacherMappings = new List<SubjectAndTeacher>();
        
        }
    }
}