using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Elements;
using System.Linq;
using UnityEngine.U2D;

public class SpellController : MonoBehaviour
{
    [SerializeField]
    private Sprite Fire;
    [SerializeField]
    private Sprite Lightning;
    [SerializeField]
    private Sprite Laser;
    [SerializeField]
    private Sprite Explosive;

    private SpriteAtlas spriteAtlas;

    private PlayerController playerController;

    private GameObject playerSpells;

    // Start is called before the first frame update
    void Start()
    {
        playerSpells = CreatePlayerSpells();
        playerController = GetComponent<PlayerController>();
        spriteAtlas = Resources.Load<SpriteAtlas>("Character/Spells/SpellHitbox");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) this.Shoot();

    }

    void Shoot()
    {
        this.playerController.Spell.Shoot(spriteAtlas);
    }

    public void Clear()
    {
        foreach (Transform child in playerSpells.transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void UpdateSpellGui(List<BaseElement> els)
    {
        GameObject spells = playerSpells;
        // GameObject player = GameObject.Find("player");



        // Element sprite
        GameObject obj = new GameObject();

        // Add required components
        obj.AddComponent<ElementController>().SetSlot(els.Count);
        var renderer = obj.AddComponent<SpriteRenderer>();
        var type = els.Last();
        if (type is Fire) renderer.sprite = Fire;
        else if (type is Lightning) renderer.sprite = Lightning;
        else if (type is Laser) renderer.sprite = Laser;
        else if (type is Explosive) renderer.sprite = Explosive;

        obj.transform.SetParent(spells.transform);
    }

    private static GameObject CreatePlayerSpells()
    {
        GameObject spells = new GameObject();
        spells.name = "playerSpells";
        return spells;
    }
}
