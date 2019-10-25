using System.Collections;
using UnityEngine;

public class FootprintController : MonoBehaviour {
    // Start is called before the first frame update
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        StartCoroutine(FadeTo(0, 1));
    }

    // Credit to http://answers.unity.com/comments/1504789/view.html
    private IEnumerator FadeTo(float aValue, float aTime) {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime) {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}