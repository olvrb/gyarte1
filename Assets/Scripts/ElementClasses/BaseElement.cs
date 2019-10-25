using UnityEngine;

namespace Assets.Scripts.Elements {
    public abstract class BaseElement {
        public abstract string Name { get; set; }
        public abstract AudioClip SoundEffect { get; set; }
        public abstract Sprite CastSprite { get; set; }
    }
}