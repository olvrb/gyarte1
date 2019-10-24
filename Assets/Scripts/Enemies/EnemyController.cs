﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject player;
    public void SetPlayer(GameObject player) {
        this.player = player;
    }

    // Start is called before the first frame update
    void Start() {
        GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update() {
        MoveTowards();
        float NaN = Single.NaN;
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