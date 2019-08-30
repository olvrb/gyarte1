using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Elements;
using System.Linq;

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

    private GameObject playerSpells;

    // Start is called before the first frame update
    void Start()
    {
        playerSpells = CreatePlayerSpells();
    }

    // Update is called once per frame
    void Update()
    {

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
        GameObject player = GameObject.Find("player");



        // Element sprite
        GameObject obj = new GameObject();

        // Add required components
        obj.AddComponent<ElementController>().SetSlot(els.Count);
        var renderer = obj.AddComponent<SpriteRenderer>();

        switch (els.Last().GetType().Name)
        {
            case "Fire":
                renderer.sprite = Fire;
                break;
            case "Lightning":
                renderer.sprite = Lightning;
                break;
            case "Laser":
                renderer.sprite = Laser;
                break;
            case "Explosive":
                renderer.sprite = Explosive;
                break;

            default:
                break;
        }

        // obj.transform.position = new Vector3(0, 0);
        obj.transform.SetParent(spells.transform);

    }

    private static GameObject CreatePlayerSpells()
    {
        GameObject spells = new GameObject();
        spells.name = "playerSpells";
        return spells;
    }
}
