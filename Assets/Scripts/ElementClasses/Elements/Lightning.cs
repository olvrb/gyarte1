using UnityEngine;

namespace Assets.Scripts.Elements {
    internal class Lightning : BaseElement {
        public Lightning() => Name = "Lightning";
        public override string Name { get; set; }
        public override AudioClip SoundEffect { get; set; }
        public override Sprite CastSprite { get; set; }
    }
}