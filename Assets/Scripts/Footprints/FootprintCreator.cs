using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintCreator : MonoBehaviour
{
    [SerializeField]
    private Sprite FootprintSprite;
    [SerializeField]
    private uint SpawnFrequency;
    private GameObject Footprints;
    // Start is called before the first frame update
    void Start()
    {
        Footprints = CreateFootprintContainer();

    }

    // Update is called once per frame
    void Update()
    {
        System.Random rand = new System.Random();
        // Every ~n frame
        if (Time.frameCount % SpawnFrequency + rand.Next(0, 1) == 0)
        {
            GameObject footprint = CreateFootprint();
        }
    }

    // We use an empty GameObject container to avoid clogging up the editor.
    private GameObject CreateFootprintContainer()
    {
        GameObject footprints = new GameObject();
        footprints.name = "footprints";
        return footprints;
    }

    private GameObject CreateFootprint()
    {
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
