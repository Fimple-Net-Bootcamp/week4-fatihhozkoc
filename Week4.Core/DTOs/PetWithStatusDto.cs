using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Core.DTOs
{
    public class PetWithStatusDto:PetDto
    {
        public List<GetHealthStatusDto> statuses { get; set; }
    }
}
