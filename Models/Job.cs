using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace Recruitment_System_Management1.Models
{

    public class Job
    {
        
        public int Id { get; set; }
        [DisplayName("Job Name")]
        public string JobTitle { get; set; }
        [DisplayName("Job Describtion")]
        public string JobContent { get; set; }
        [DisplayName("Job Image")]
        public string JobImage { get; set; }

        public string UserID { get; set; }

        [DisplayName("Job Type")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}