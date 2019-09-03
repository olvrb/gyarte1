using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Elements
{
    class Laser : BaseElement
    {
        public override string Name { get; set; }
        public Laser() => Name = "Laser";
    }
}
