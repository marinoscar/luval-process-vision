using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class PredictionResult
    {
        [JsonProperty(PropertyName = "probability")]
        public decimal Probability { get; set; }
        [JsonProperty(PropertyName = "tagId")]
        public string TagId { get; set; }
        [JsonProperty(PropertyName = "tagName")]
        public string TagName { get; set; }
        [JsonProperty(PropertyName = "boundingBox")]
        public PredictionBoundingBox BoundingBox { get;set;}
    }
}
