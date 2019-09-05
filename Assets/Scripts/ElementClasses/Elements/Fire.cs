using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Elements
{
    class Fire : BaseElement
    {
        public override string Name { get; set; }
        public override AudioClip SoundEffect { get; set; }
        public Fire()
        {
            Name = "Fire";
            SoundEffect = Resources.Load<AudioClip>("Character/Spells/Audio/fire");
        }
    }
}
