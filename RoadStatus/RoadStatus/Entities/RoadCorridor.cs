using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatus.Entities
{
    public class RoadCorridor
    {

        public string ID { get; set; }
        public string DisplayName { get; set; }

        public string StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
    }
}
