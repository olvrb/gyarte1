using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    [SerializeField] private Sprite EnemySprite;
    [SerializeField] private GameObject Constraint;
    [SerializeField] private GameObject player;
    [SerializeField] private PhysicsMaterial2D Material;
    [SerializeField] private GameObject Template;

    private static readonly System.Random random = new System.Random();
    private readonly int numberOfEnemies = random.Next(5, 15);

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++) {
            GameObject obj = Instantiate(Template, RandomCoordinate(), Quaternion.identity);
            obj.GetComponent<EnemyController>().SetPlayer(player);
        }
    }

    Vector2 RandomCoordinate() => Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
    // Update is called once per frame
    void Update()
    {
        
    }
}
