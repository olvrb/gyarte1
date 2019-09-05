using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Elements
{
    public abstract class BaseElement
    {
        public abstract string Name { get; set; }
        public abstract AudioClip SoundEffect { get; set; }
    }
}
