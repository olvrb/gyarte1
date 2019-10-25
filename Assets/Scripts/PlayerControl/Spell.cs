using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Elements;
using UnityEngine;
using UnityEngine.U2D;
using Assets.Scripts.SpellCast;

namespace Assets.Scripts
{
    public class Spell
    {
        public Spell()
        {
            player = GameObject.Find("player");
        }
        private GameObject player;
        public List<BaseElement> Elements = new List<BaseElement>();

        public Spell AddElemet(BaseElement el)
        {
            if (Elements.Count < 3)
            {
                Elements.Add(el);
                player.GetComponent<SpellController>().UpdateSpellGui(this.Elements);
                player.GetComponent<Telemetry>().SubmitTelemetry(el);

                AudioSource audioSource = player.GetComponent<AudioSource>();
                audioSource.clip = el.SoundEffect;
                audioSource.Play();
            }

            return this;
        }

        public Spell Shoot(SpriteAtlas spriteAtlas)
        {
            if (!IsReadyToFire) return this;
            GameObject obj = GenerateSpellObject(spriteAtlas);
            Reset();
            return this;
        }

        public GameObject GenerateSpellObject(SpriteAtlas spriteAtlas) {
            return null;
            GameObject obj = new GameObject();

            obj = SetShapeSprite(obj, spriteAtlas);

            SpellCastController cont =  obj.AddComponent<SpellCastController>();
            cont.SetPlayer(player);

            return obj;
        }

        public GameObject SetShapeSprite(GameObject obj, SpriteAtlas spriteAtlas)
        {
            SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
            if (this.Shape is Fire) renderer.sprite = spriteAtlas.GetSprite("spellhitbox_45");
            else if (this.Shape is Lightning) spriteAtlas.GetSprite("spellhitbox_45");
            else if (this.Shape is Laser) spriteAtlas.GetSprite("spellhitbox_45");
            else if (this.Shape is Explosive) spriteAtlas.GetSprite("spellhitbox_45");
            return obj;
        }

        public Spell Reset()
        {
            this.Elements = new List<BaseElement>();
            player.GetComponent<SpellController>().Clear();
            return this;
        }
        public string FormatComponents() =>
            this.Elements == null || this.Elements.Count == 0 ?
            "none" :
            this.Elements.Select(x => x.GetType().Name).Aggregate((i, j) => $"{i}, {j}");

        public bool IsReadyToFire { get => this.Elements.Count > 0; }
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
