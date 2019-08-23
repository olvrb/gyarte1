using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Elements;

namespace Assets.Scripts
{
    public class Spell
    {
        public List<BaseElement> Elements = new List<BaseElement>();

        public Spell AddElemet(BaseElement el)
        {
            if (Elements.Count < 3) Elements.Add(el);
            return this;
        }
        public string FormatComponents() =>
            this.Elements == null || this.Elements.Count == 0 ?
            "none" :
            this.Elements.Select(x => x.GetType().Name).Aggregate((i, j) => $"{i}, {j}");
        public BaseElement Shape {
            get => Elements[0];
            private set => Elements[0] = value;
        }
        public BaseElement Type {
            get {
                return Elements[1];
            }
            private set {
                Elements[1] = value;
            }
        }
        public BaseElement Effect {
            get {
                return Elements[2];
            }
            private set {
                Elements[2] = value;
            }
        }

        public Spell SetShape(BaseElement el)
        {
            this.Shape = el;
            return this;
        }

        public Spell SetType(BaseElement el)
        {
            this.Type = el;
            return this;
        }
        public Spell SetEffect(BaseElement el)
        {
            this.Effect = el;
            return this;
        }

    }
}
