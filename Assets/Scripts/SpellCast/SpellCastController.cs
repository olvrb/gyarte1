using UnityEngine;

namespace Assets.Scripts.SpellCast {
    internal class SpellCastController : MonoBehaviour {
        private GameObject player;
        private PlayerController playerController;

        public void SetPlayer(GameObject player) {
            this.player = player;
            playerController = player.GetComponent<PlayerController>();
        }

        private void Start() {
            MoveToPlayer();
        }

        private void Update() {
            MoveToPlayer();
        }

        private void MoveToPlayer() {
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;

            Vector3 spawnPos = playerPos + transform.forward * 100;


            transform.position = playerController.SpellSlot;
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 100 * Time.deltaTime);
        }
    }
}