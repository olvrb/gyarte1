using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Elements
{
    class ElementController : MonoBehaviour
    {
        private GameObject player;
        private int slot;

        public void SetSlot(int i)
        {
            print(i);
            slot = i;
        }

        private void Start()
        {
            player = GameObject.Find("player");
        }

        private void Update()
        {
            Vector3 slot = new Vector3();
            switch (this.slot)
            {
                case 1:
                    slot = player.GetComponent<PlayerController>().Slot1;
                    break;
                case 2:
                    slot = player.GetComponent<PlayerController>().Slot2;
                    break;
                case 3:
                    slot = player.GetComponent<PlayerController>().Slot3;
                    break;
                default:
                    break;
            }
            transform.position = slot;
        }
    }
}
