using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SpellCast {
    internal class SpellCastController : MonoBehaviour {
        private GameObject player;
        private PlayerController playerController;
        private Rigidbody2D rigidbody2D;

        public void SetPlayer(GameObject player) {
            this.player = player;
            playerController = player.GetComponent<PlayerController>();

            rigidbody2D = GetComponent<Rigidbody2D>();

        }

        private void Start() {
            MoveToPlayer();
            StartCoroutine(FadeTo(0, 1));
        }

        private void Update() {
            transform.position = 0.1f * player.transform.up + transform.position;

        }

        private void MoveToPlayer() {
            transform.position = player.transform.position; 

            float rotationZ = player.transform.localEulerAngles.z + 70;

            transform.rotation =
                Quaternion.Euler(0, 0, rotationZ);

        }

        void OnCollisionStay2D(Collision2D other) {
            if (other.gameObject.name.Contains("Enemy")) {
                Character controller = other.gameObject.GetComponent<Character>();
                controller.ReceiveDamage(1);
            }
        }

        private IEnumerator FadeTo(float aValue, float aTime)
        {
            float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
                transform.GetComponent<SpriteRenderer>().material.color = newColor;
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}