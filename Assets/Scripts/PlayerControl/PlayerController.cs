using Assets.Scripts;
using Assets.Scripts.Elements;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PlayerController : Character {
    private Rigidbody2D body;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float speed;
    public Spell Spell;

    private readonly float ySpellDifference = 1f;

    public Vector3 Slot1 => new Vector3(transform.position.x - 0.5f, transform.position.y - ySpellDifference);
    public Vector3 Slot2 => new Vector3(transform.position.x, transform.position.y - ySpellDifference);
    public Vector3 Slot3 => new Vector3(transform.position.x + 0.5f, transform.position.y - ySpellDifference);

    public Vector3 SpellSlot => new Vector3(transform.position.x, transform.position.y) + body.transform.forward * 800;

    private void Awake() {
    }

    private void SetRandomSprite() {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Character/PlayerSprites");
        SpriteRenderer.sprite = sprites[new Random().Next(1, sprites.Length)];
    }

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        body = GetComponent<Rigidbody2D>();
        // SetRandomSprite();
        MaxHp = 20;
        Hp = MaxHp;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
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

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rotZ - 90),
            rotationSpeed * Time.deltaTime);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        print("gameover");
    }
}