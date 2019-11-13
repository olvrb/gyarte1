using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemyGenerator : MonoBehaviour {
    private static readonly Random random = new Random();
    private readonly int numberOfEnemies = random.Next(5, 15);
    [SerializeField] private GameObject Constraint;
    [SerializeField] private Sprite EnemySprite;
    [SerializeField] private PhysicsMaterial2D Material;
    [SerializeField] private GameObject player;
    private GameObject[] Templates;

    private static readonly Random Rand = new Random();
    private GameObject RandomTemplate => Templates[Rand.Next(0, Templates.Length)];
    

    private void Start() {
        // Load all enemies from the directory.
        Templates = Resources.LoadAll<GameObject>("Prefabs/Enemies");
        for (int i = 0; i < numberOfEnemies; i++) {
            GameObject obj = Instantiate(RandomTemplate, RandomCoordinate(), Quaternion.identity);
            obj.GetComponent<EnemyController>().SetPlayer(player);
        }
    }

    private Vector2 RandomCoordinate() =>
        Camera.main.ViewportToWorldPoint(new Vector2(UnityEngine.Random.value, UnityEngine.Random.value));

    // Update is called once per frame
    private void Update() {
    }
}