using UnityEngine;

public class CameraController : MonoBehaviour {
    private Vector3 offset;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    private void Start() {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    private void Update() {
        transform.position = player.transform.position + offset;
    }
}