using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : EnemyController
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

    public void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
    }
}
