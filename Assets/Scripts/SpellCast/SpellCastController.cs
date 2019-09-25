using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpellCast
{
    class SpellCastController : MonoBehaviour
    {
        private GameObject player;
        private PlayerController playerController;
        public void SetPlayer(GameObject player)
        {
            this.player = player;
            this.playerController = player.GetComponent<PlayerController>();
        }
        void Start()
        {
            MoveToPlayer();
        }

        void Update()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;

            Vector3 spawnPos = playerPos + transform.forward * 100;


            transform.position = playerController.SpellSlot;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, player.transform.rotation, 100 * Time.deltaTime);
        }
    }
}
