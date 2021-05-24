﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace Recruitment_System_Management1.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }

        public Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}