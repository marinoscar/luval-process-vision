using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class PredictionBoundingBox
    {
        [JsonProperty(PropertyName = "left")]
        public decimal Left { get; set; }
        [JsonProperty(PropertyName = "top")]
        public decimal Top { get; set; }
        [JsonProperty(PropertyName = "width")]
        public decimal Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public decimal Height { get; set; }

    }
}
