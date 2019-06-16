using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class OcrWord : OcrBoundingBox
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
