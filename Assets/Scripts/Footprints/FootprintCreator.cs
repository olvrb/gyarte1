﻿using UnityEngine;
using Random = System.Random;

public class FootprintCreator : MonoBehaviour {
    private GameObject Footprints;
    private Sprite FootprintSprite;

    [SerializeField] private uint SpawnFrequency;

    // Start is called before the first frame update
    private void Start() {
        Footprints = CreateFootprintContainer();
        SetRandomFootprintSprite();
    }

    private void SetRandomFootprintSprite() {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Character/FootprintSprites");
        FootprintSprite = sprites[new Random().Next(0, sprites.Length)];
    }

    // FixedUpdate is called once per frame, without the need for Time.deltaTime,
    // because our modulo operation doesn't work well with floats.
    private void FixedUpdate() {
        // Every ~n frame
        if (Time.frameCount % SpawnFrequency == 0) {
            GameObject footprint = CreateFootprint();
        }
    }

    // We use an empty GameObject container to avoid clogging up the editor.
    private GameObject CreateFootprintContainer() {
        GameObject footprints = new GameObject();
        footprints.name = "footprints";
        return footprints;
    }

    private GameObject CreateFootprint() {
        GameObject footprint = new GameObject();
        footprint.AddComponent<SpriteRenderer>().sprite = FootprintSprite;
        footprint.AddComponent<FootprintController>();

        // Set position and rotation equal to the player's position and rotation.
        footprint.transform.position = transform.position;
        footprint.transform.rotation = transform.rotation;

        /// Contain all footprints, <see cref="CreateFootprintContainer"/>
        footprint.transform.SetParent(Footprints.transform);
        return footprint;
    }
}