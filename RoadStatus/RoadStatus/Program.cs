using RoadStatus.Entities;
using RoadStatus.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args.Length > 0)
            {
                var roadName = args[0];
                Service service = new Service();

                Task<RoadCorridor> road = service.GetRoadStatus(roadName);

                if (road.Exception != null && road.IsFaulted ) Console.WriteLine(road.Exception.InnerException.Message);
                else
                {
                    var output = string.Format("The status of the {0} is as follows {1} Road Status is {2} {1} Road Status Description is {3}", roadName, Environment.NewLine, road.Result.StatusSeverity, road.Result.StatusSeverityDescription);
                    Console.WriteLine(output);
                }
            }
            else
                Console.WriteLine("please provide road name");
           
            

        }
    }
}
