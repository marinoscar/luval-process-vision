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
            var imgFile = @"C:\Users\ch489gt\Pictures\Snag-Auto\TestSnag.png";

            var predictService = new PredictionService();
            var predictRes = predictService.Predict(imgFile);

            var ocrService = new OcrService();
            var ocrRes = ocrService.DoOcr(imgFile);

            var analyzer = new VisionAnalyzer();
            var result = analyzer.GetResult(imgFile, predictRes.Data);
        }
    }
}
