using UnityEngine;

namespace Assets.Scripts.Elements {
    internal class Explosive : BaseElement {
        public Explosive() => Name = "Explosive";
        public override string Name { get; set; }
        public override AudioClip SoundEffect { get; set; }
        public override Sprite CastSprite { get; set; }
    }
}