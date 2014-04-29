using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class Subject 
    {
        [Key]
        public int SubjectID { get; set; }

        public string Name { get; set; }

        #region Navigation properties for Subject

        public virtual List<SubjectAndTeacher> SubjectAndTeacherMappings { get; set; }

        #endregion

        public Subject()
        {
            SubjectAndTeacherMappings = new List<SubjectAndTeacher>();
        }


        public static List<Subject> getSubjects() { 
        
            using(Repository repo =new Repository()){

                return (repo.Subjects.ToList());
            }
        
        
        }
    }
}