using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintCreator : MonoBehaviour
{
    public Sprite FootprintSprite;
    private GameObject Footprints;
    // Start is called before the first frame update
    void Start()
    {
        Footprints = CreateFootprintContainer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 15 == 0)
        {
            GameObject footprint = CreateFootprint();
        }
    }

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

        footprint.transform.position = transform.position;
        footprint.transform.rotation = transform.rotation;

        footprint.transform.SetParent(Footprints.transform);
        return footprint;
    }
}
