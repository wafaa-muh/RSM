using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Recruitment_System_Management1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Type of Employment")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name ="Description Type")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}