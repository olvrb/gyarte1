using Assets.Scripts;
using UnityEngine;

public class EnemyController : Character {
    private GameObject player;


    public void SetPlayer(GameObject player) {
        this.player = player;
    }

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        SpriteRenderer.flipX = true;
        MaxHp = 10;
        Hp = MaxHp;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        MoveTowards();
    }

    public void GameOver() {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collider = other.gameObject;
        if (collider.name == "player")
        {
            PlayerController cont = collider.GetComponent<PlayerController>();
            cont.ReceiveDamage(1);
        }
    }

    private void MoveTowards() {
        // Change rotation
        transform.right =
            player.transform.position -
            transform.position;

        // Move towards player
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
    }
}