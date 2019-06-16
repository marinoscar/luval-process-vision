using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class VisionObject
    {
        public string TagName { get; set; }
        public decimal Probability { get; set; }
        public Rectangle Location { get; set; }
        public OcrResponse OcrResult { get; set; }
    }
}
