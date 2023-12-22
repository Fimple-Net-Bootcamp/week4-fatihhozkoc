using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Core.DTOs
{
    public class GetActivitiesDto
    {
        public int Id { get; set; }
        public ActivityType ActivityType { get; set; }
        public ActivityStatus Status { get; set; }
        public ActivityEffect Effect { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
