﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Elements
{
    class ElementController : MonoBehaviour
    {
        /// <summary>
        /// The object the element will be attached to.
        /// </summary>
        private GameObject player;
        /// <summary>
        /// Which slot the Element will sit in.
        /// </summary>
        private int slot;
        PlayerController playerController;

        public void SetSlot(int i)
        {
            slot = i;
        }

        private void Start()
        {
            player = GameObject.Find("player");
            playerController = player.GetComponent<PlayerController>();

            // Call method as soon as object is created 
            MoveToPlayer();
        }


        private void Update()
        {
            MoveToPlayer();
        }

        private void MoveToPlayer()
        {
            Vector3 slot = new Vector3();

            // Select which slot the element is supposed to sit in.
            switch (this.slot)
            {
                case 1:
                    slot = playerController.Slot1;
                    break;
                case 2:
                    slot = playerController.Slot2;
                    break;
                case 3:
                    slot = playerController.Slot3;
                    break;
                default:
                    break;
            }
            transform.position = slot;
        }
    }
}