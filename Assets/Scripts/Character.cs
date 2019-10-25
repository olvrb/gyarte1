using UnityEngine;

namespace Assets.Scripts {
    public class Character : MonoBehaviour {
        public uint Hp { get; protected set; }

        public void Damage(uint amount) {
            Hp -= amount;
        }
    }
}