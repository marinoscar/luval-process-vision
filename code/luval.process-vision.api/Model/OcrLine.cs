using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class OcrLine : OcrBoundingBox
    {
        [JsonProperty(PropertyName = "words")]
        public List<OcrWord> Words { get; set; }

        public override string ToString()
        {
            var words = Words.OrderBy(w => w.ToRectangle().X).Select(w => w.Text);
            return string.Join(" ", words);
        }
    }
}
