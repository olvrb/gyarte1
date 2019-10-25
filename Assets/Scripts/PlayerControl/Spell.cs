using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Elements;
using Assets.Scripts.SpellCast;
using UnityEngine;
using UnityEngine.U2D;

namespace Assets.Scripts {
    public class Spell {
        public List<BaseElement> Elements = new List<BaseElement>();
        private readonly GameObject player;

        public Spell() => player = GameObject.Find("player");

        public bool IsReadyToFire => Elements.Count > 0;

        public BaseElement Shape {
            get => Elements[0];
            private set => Elements[0] = value;
        }

        public BaseElement Type {
            get => Elements[1];
            private set => Elements[1] = value;
        }

        public BaseElement Effect {
            get => Elements[2];
            private set => Elements[2] = value;
        }

        public Spell AddElemet(BaseElement el) {
            if (Elements.Count < 3) {
                Elements.Add(el);
                player.GetComponent<SpellController>().UpdateSpellGui(Elements);
                player.GetComponent<Telemetry>().SubmitTelemetry(el);

                AudioSource audioSource = player.GetComponent<AudioSource>();
                audioSource.clip = el.SoundEffect;
                audioSource.Play();
            }

            return this;
        }

        public Spell Shoot(SpriteAtlas spriteAtlas) {
            if (!IsReadyToFire) {
                return this;
            }

            GameObject obj = GenerateSpellObject(spriteAtlas);
            Reset();
            return this;
        }

        public GameObject GenerateSpellObject(SpriteAtlas spriteAtlas) {
            return null;
            GameObject obj = new GameObject();

            obj = SetShapeSprite(obj, spriteAtlas);

            SpellCastController cont = obj.AddComponent<SpellCastController>();
            cont.SetPlayer(player);

            return obj;
        }

        public GameObject SetShapeSprite(GameObject obj, SpriteAtlas spriteAtlas) {
            SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
            if (Shape is Fire) {
                renderer.sprite = spriteAtlas.GetSprite("spellhitbox_45");
            }
            else if (Shape is Lightning) {
                spriteAtlas.GetSprite("spellhitbox_45");
            }
            else if (Shape is Laser) {
                spriteAtlas.GetSprite("spellhitbox_45");
            }
            else if (Shape is Explosive) {
                spriteAtlas.GetSprite("spellhitbox_45");
            }

            return obj;
        }

        public Spell Reset() {
            Elements = new List<BaseElement>();
            player.GetComponent<SpellController>().Clear();
            return this;
        }

        public string FormatComponents() =>
            Elements == null || Elements.Count == 0
                ? "none"
                : Elements.Select(x => x.GetType().Name).Aggregate((i, j) => $"{i}, {j}");

        public Spell SetShape(BaseElement el) {
            Shape = el;
            return this;
        }

        public Spell SetType(BaseElement el) {
            Type = el;
            return this;
        }

        public Spell SetEffect(BaseElement el) {
            Effect = el;
            return this;
        }
    }
}