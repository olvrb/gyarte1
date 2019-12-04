using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        base.Update();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }
}
