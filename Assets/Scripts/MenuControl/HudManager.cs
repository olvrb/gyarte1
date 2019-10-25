using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    internal class HudManager : MonoBehaviour {
        [SerializeField] private GameObject CurrentSpell;

        public void UpdateSpells(string form) {
            CurrentSpell.GetComponent<Text>().text = form;
        }
    }
}