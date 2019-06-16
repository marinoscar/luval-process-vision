using luval.process_vision.api.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api
{
    public class PredictionService
    {
        public PredictionResponse Predict(string imageFileName)
        {
            var serviceUrl = ConfigurationManager.AppSettings["api.custom-vision.prediction.url.file"];
            var serviceKey = ConfigurationManager.AppSettings["api.custom-vision.key"];
            return null;
        }
    }
}
