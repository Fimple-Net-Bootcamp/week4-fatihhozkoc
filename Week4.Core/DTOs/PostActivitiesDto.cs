using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Core.DTOs
{
    public class PostActivitiesDto
    {
        public ActivityType ActivityType { get; set; }
        public ActivityStatus Status { get; set; }
        public ActivityEffect Effect { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }

        public PostActivitiesDto()
        {
            EndTime = StartTime.AddHours(1);
        }
    }
}
