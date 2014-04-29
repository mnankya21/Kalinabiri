using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class Parent : Address
    {
        #region Parent Properties

        [Key]
        public int ParentID { get; set; }
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string PlaceOfWork { get; set; }
        //public byte[] Photo { get; set; }
        public string TelephoneNumber { get; set; }
        //public string ContentType { get; set; }

        #endregion

        #region Navigation properties for parent

        public virtual List<Pupil> pupils { get; set; }
        public virtual District District { get; set; }
        #endregion



        //method to return all parents

        public static List<Parent> GetParents()
        {
            using (Repository repo = new Repository())
            {
                return (repo.Parents.ToList());
            }

        }
        //initilize pupil list
        public Parent()
        {

            pupils = new List<Pupil>();

        }

    }
}