using UnityEngine;

namespace Assets.Scripts.Elements {
    internal class Fire : BaseElement {
        public Fire() {
            Name = "Fire";
            SoundEffect = Resources.Load<AudioClip>("Character/Spells/Audio/fire");
        }

        public override string Name { get; set; }
        public override AudioClip SoundEffect { get; set; }

        public override Sprite CastSprite { get; set; }
    }
}