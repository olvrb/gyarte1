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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSpellGui(List<BaseElement> els)
    {
        print(els.Count != 0 ? els.Select(i => i.GetType().Name).Aggregate((i, j) => $"{i}, {j}") : "none");
        GameObject obj = new GameObject();
        obj.AddComponent<SpriteRenderer>().sprite ;
    }
}
