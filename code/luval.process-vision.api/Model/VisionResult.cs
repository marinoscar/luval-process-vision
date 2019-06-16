using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.process_vision.api.Model
{
    public class VisionResult
    {
        public VisionObject Box { get; set; }
        public List<VisionObject> Buttons { get; set; }
    }
}
