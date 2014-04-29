using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class House
    {
        [Key]
        public int HouseID { get; set; }
        public string Name { get; set; }
        public string color { get; set; }

        #region Navigation properties for House

        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Pupil> Pupils { get; set; }
       
        #endregion

        public House() {
            Teachers = new List<Teacher>();
            Pupils = new List<Pupil>();
        
        }

        public static List<House> getHouses(){

            using (Repository repo = new Repository())
            {

                return (repo.House.ToList());
            }
        
        
        }
    }
}