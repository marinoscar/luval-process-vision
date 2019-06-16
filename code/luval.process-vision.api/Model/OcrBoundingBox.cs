using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class OcrBoundingBox
    {
        [JsonProperty(PropertyName = "boundingBox")]
        public string BoundingBox { get; set; }

        public Rectangle ToRectangle()
        {
            var values = BoundingBox.Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
            return new Rectangle()
            {
                X = values[0],
                Y = values[1],
                Width = values[2],
                Height = values[3]
            };
        }
    }
}
