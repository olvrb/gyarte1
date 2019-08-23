using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Elements;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D body;

    public Spell Spell;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateSpell();
        RotateObject();
        MoveObject();
    }

    private void CreateSpell()
    {
        if (this.Spell == null) InitSpell();

        // These keys should be rebindable
        if (Input.GetKeyUp(KeyCode.Alpha1)) this.Spell.AddElemet(new Fire());
        else if (Input.GetKeyUp(KeyCode.Alpha2)) this.Spell.AddElemet(new Lightning());
        else if (Input.GetKeyUp(KeyCode.Alpha3)) this.Spell.AddElemet(new Laser());
        else if (Input.GetKeyUp(KeyCode.Alpha4)) this.Spell.AddElemet(new Explosive());
        GameObject.Find("Canvas").GetComponent<GuiManager>().UpdateSpells(this.Spell.FormatComponents());
        GetComponent<SpellController>().UpdateSpellGui(this.Spell.Elements);
    }

    private void InitSpell()
    {
        this.Spell = new Spell();
    }

    private void MoveObject()
    {
        transform.Translate(speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime);
    }

    private void RotateObject()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), rotationSpeed * Time.deltaTime);
    }
}
