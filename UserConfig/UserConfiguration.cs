using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserConfig
{
    [Serializable()]
    public class UserConfiguration
    {
        
        public int Height { get; set; }
        public int Width { get; set; }
        public int LocationY { get; set; }
        public int LocationX { get; set; }

    }
}
