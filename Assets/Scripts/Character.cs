using UnityEngine;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour
    {
        public int Hp { get; protected set; }
        protected int MaxHp { get; set; }
        protected SpriteRenderer SpriteRenderer;
        public bool IsAlive => Hp > 0;

        public void ReceiveDamage(int amount) {
            if (Hp == 0) return;
            if (IsAlive) Hp -= amount;
        }

        public void Kill() {
            Hp = 0;
        }

        public void Heal(uint amount) {
            if (Hp + amount > MaxHp) Hp = MaxHp;

            Hp += (int)amount;
        }

        protected virtual void Start() {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
        protected virtual void Update()
        {
            if (!IsAlive) Destroy(this.gameObject);
            Color rend = SpriteRenderer.color;
            rend.a = (float)Hp / (float)MaxHp;
            SpriteRenderer.color = rend;
        }
    }
}
