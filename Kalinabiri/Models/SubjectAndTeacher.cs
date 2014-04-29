using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalinabiri.Models
{
    public class SubjectAndTeacher
    {

        #region Subject and teacher mapping properties
        [Key]
        public int SubjectTeacherID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public string classAttached { get; set; }
        #endregion


        #region navigation propeeties

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }

        #endregion

    }
}