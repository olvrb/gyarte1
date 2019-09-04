using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{

    class HudManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject CurrentSpell;
        public void UpdateSpells(string form)
        {
            CurrentSpell.GetComponent<Text>().text = form;
        }
    }
}
