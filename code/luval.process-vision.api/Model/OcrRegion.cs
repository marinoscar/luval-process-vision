using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class OcrRegion : OcrBoundingBox
    {
        [JsonProperty(PropertyName = "lines")]
        public List<OcrLine> Lines { get; set; }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Lines.Select(l => l.ToString()));
        }
    }
}
