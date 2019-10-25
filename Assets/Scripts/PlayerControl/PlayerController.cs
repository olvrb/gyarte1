﻿using Assets.Scripts;
using Assets.Scripts.Elements;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D body;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float speed;

    public Spell Spell;

    private readonly float ySpellDifference = 1f;

    public Vector3 Slot1 => new Vector3(transform.position.x - 0.5f, transform.position.y - ySpellDifference);
    public Vector3 Slot2 => new Vector3(transform.position.x, transform.position.y - ySpellDifference);
    public Vector3 Slot3 => new Vector3(transform.position.x + 0.5f, transform.position.y - ySpellDifference);

    public Vector3 SpellSlot => new Vector3(transform.position.x, transform.position.y) + transform.forward * 100;

    private void Awake() {
        SetRandomSprite();
    }

    private void SetRandomSprite() {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Character/PlayerSprites");
        GetComponent<SpriteRenderer>().sprite = sprites[new Random().Next(1, sprites.Length)];
    }

    // Start is called before the first frame update
    private void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        CreateSpell();
        RotateObject();
        MoveObject();
    }

    private void CreateSpell() {
        if (Spell == null) {
            InitSpell();
        }

        // These keys should be rebindable
        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Spell.AddElemet(new Fire());
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Spell.AddElemet(new Lightning());
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Spell.AddElemet(new Laser());
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4)) {
            Spell.AddElemet(new Explosive());
        }

        GameObject.Find("Canvas").GetComponent<HudManager>().UpdateSpells(Spell.FormatComponents());
    }

    private void InitSpell() {
        Spell = new Spell();
    }

    private void MoveObject() {
        transform.Translate(
            speed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime);
    }

    private void RotateObject() {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90),
            rotationSpeed * Time.deltaTime);
    }
}