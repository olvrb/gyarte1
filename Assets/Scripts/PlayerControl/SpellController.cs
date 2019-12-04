using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Elements;
using UnityEngine;
using UnityEngine.U2D;

public class SpellController : MonoBehaviour {
    [SerializeField] private Sprite Explosive;

    [SerializeField] private Sprite Fire;

    [SerializeField] private Sprite Laser;

    [SerializeField] private Sprite Lightning;

    private PlayerController playerController;

    private GameObject playerSpells;

    private SpriteAtlas spriteAtlas;

    // Start is called before the first frame update
    private void Start() {
        playerSpells = CreatePlayerSpells();
        playerController = GetComponent<PlayerController>();
        spriteAtlas = Resources.Load<SpriteAtlas>("Character/Spells/SpellHitbox");
    }

    // Update is called once per frame
    private void Update() {
        Shoot();

        // if (Input.GetKeyUp(KeyCode.Space)) {
        //     Shoot();
        // }
    }

    private void Shoot() {
        playerController.Spell.Shoot(spriteAtlas);
    }

    public void Clear() {
        foreach (Transform child in playerSpells.transform) {
            Destroy(child.gameObject);
        }
    }


    public void UpdateSpellGui(List<BaseElement> els) {
        GameObject spells = playerSpells;
        // GameObject player = GameObject.Find("player");


        // Element sprite
        GameObject obj = new GameObject();

        // Add required components
        obj.AddComponent<ElementController>().SetSlot(els.Count);
        SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
        BaseElement type = els.Last();
        if (type is Fire) {
            renderer.sprite = Fire;
        }
        else if (type is Lightning) {
            renderer.sprite = Lightning;
        }
        else if (type is Laser) {
            renderer.sprite = Laser;
        }
        else if (type is Explosive) {
            renderer.sprite = Explosive;
        }

        obj.transform.SetParent(spells.transform);
    }

    private static GameObject CreatePlayerSpells() {
        GameObject spells = new GameObject();
        spells.name = "playerSpells";
        return spells;
    }
}