using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Elements
{
    class Explosive : BaseElement
    {
        public override string Name { get; set; }
        public override AudioClip SoundEffect { get; set; }
        public override Sprite CastSprite { get; set; }

        public Explosive() => Name = "Explosive";
    }
}
