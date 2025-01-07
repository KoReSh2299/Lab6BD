using Kursach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Domain.Filters
{
    public class ParkingSpaceFilter
    {
        public bool? IsPenalty { get; set; } = null;

        //CarId = -1, если необходимо выбрать свободные места
        public int? CarId { get; set; } = -1;
    }

}
