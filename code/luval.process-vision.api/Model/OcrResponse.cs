using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class OcrResponse
    {
        [JsonProperty(PropertyName = "language")]
        public string language { get; set; }
        [JsonProperty(PropertyName = "textAngle")]
        public decimal textAngle { get; set; }
        [JsonProperty(PropertyName = "orientation")]
        public string orientation { get; set; }
        [JsonProperty(PropertyName = "regions")]
        public List<OcrRegion> Regions { get; set; }
    }
}
