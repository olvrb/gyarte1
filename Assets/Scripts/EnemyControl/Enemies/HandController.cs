using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void OnCollisionEnter2D(Collision2D other) {
        GameObject collider = other.gameObject;
        if (collider.name == "player") {
            PlayerController cont = collider.GetComponent<PlayerController>();
            cont.ReceiveDamage(1);
        }
    }
}
