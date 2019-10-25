using UnityEngine;

namespace Assets.Scripts.SpellCast {
    public class SpellCollider : MonoBehaviour {
        // Start is called before the first frame update
        private void Start() {
        }

        // Update is called once per frame
        private void Update() {
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            print(collision);
        }
    }
}