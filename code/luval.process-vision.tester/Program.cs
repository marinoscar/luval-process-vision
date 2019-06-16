using luval.process_vision.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace luval.process_vision.tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PredictionService();
            var response = service.Predict(@"C:\Users\ch489gt\Pictures\Snag-Auto\SNAG-0019.png");
        }
    }
}
