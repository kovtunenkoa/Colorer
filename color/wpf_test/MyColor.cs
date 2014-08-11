using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_test
{
    public class MyColor
    {
        public MyColor(System.Drawing.Color color)
        {
            _color = color;
        }

        private System.Drawing.Color _color;
        public string Name
        {
            get { return _color.Name; }
        }
    }
}
