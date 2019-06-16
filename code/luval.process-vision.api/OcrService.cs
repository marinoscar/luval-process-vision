using luval.process_vision.api.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api
{
    public class OcrService
    {
        public IRestResponse<OcrResponse> DoOcr(string imageFileName)
        {
            var file = new FileInfo(imageFileName);
            return DoOcr(file, File.ReadAllBytes(file.FullName));
        }

        public IRestResponse<OcrResponse> DoOcr(FileInfo file, byte[] body)
        {
            var serviceUrl = ConfigurationManager.AppSettings["api.computer-vision.ocr.url"];
            var serviceKey = ConfigurationManager.AppSettings["api.computer-vision.key"];
            var client = new RestClient(serviceUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Ocp-Apim-Subscription-Key", serviceKey);
            request.AddParameter("content", body, ParameterType.RequestBody);
            var response = client.Execute<OcrResponse>(request);
            return response;
        }
    }
}
