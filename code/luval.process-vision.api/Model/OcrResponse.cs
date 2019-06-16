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
        public string Language { get; set; }
        [JsonProperty(PropertyName = "textAngle")]
        public decimal TextAngle { get; set; }
        [JsonProperty(PropertyName = "orientation")]
        public string Orientation { get; set; }
        [JsonProperty(PropertyName = "regions")]
        public List<OcrRegion> Regions { get; set; }
    }
}
