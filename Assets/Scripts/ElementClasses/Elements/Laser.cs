using UnityEngine;

namespace Assets.Scripts.Elements {
    internal class Laser : BaseElement {
        public Laser() => Name = "Laser";
        public override string Name { get; set; }
        public override AudioClip SoundEffect { get; set; }
        public override Sprite CastSprite { get; set; }
    }
}