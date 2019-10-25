using UnityEngine;
using Random = System.Random;

public class EnemyGenerator : MonoBehaviour {
    private static readonly Random random = new Random();
    private readonly int numberOfEnemies = random.Next(5, 15);
    [SerializeField] private GameObject Constraint;
    [SerializeField] private Sprite EnemySprite;
    [SerializeField] private PhysicsMaterial2D Material;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Template;

    // Start is called before the first frame update
    private void Start() {
        for (int i = 0; i < numberOfEnemies; i++) {
            GameObject obj = Instantiate(Template, RandomCoordinate(), Quaternion.identity);
            obj.GetComponent<EnemyController>().SetPlayer(player);
        }
    }

    private Vector2 RandomCoordinate() =>
        Camera.main.ViewportToWorldPoint(new Vector2(UnityEngine.Random.value, UnityEngine.Random.value));

    // Update is called once per frame
    private void Update() {
    }
}