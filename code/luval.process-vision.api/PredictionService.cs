﻿using luval.process_vision.api.Model;
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
    public class PredictionService
    {
        public IRestResponse<PredictionResponse> Predict(string imageFileName)
        {
            var file = new FileInfo(imageFileName);
            return Predict(file, File.ReadAllBytes(file.FullName));
        }

        public IRestResponse<PredictionResponse> Predict(FileInfo file, byte[] body)
        {
            var serviceUrl = ConfigurationManager.AppSettings["api.custom-vision.prediction.url.file"];
            var serviceKey = ConfigurationManager.AppSettings["api.custom-vision.key"];
            var client = new RestClient(serviceUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("Prediction-Key", serviceKey);
            request.AddParameter("content", body, ParameterType.RequestBody);
            var response = client.Execute<PredictionResponse>(request);
            return response;
        }
    }
}
