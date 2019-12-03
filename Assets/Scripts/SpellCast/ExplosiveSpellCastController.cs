using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ExplosiveSpellCastController : MonoBehaviour
{
    private GameObject player;
    private PlayerController playerController;
    private Rigidbody2D rigidbody2D;

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        playerController = player.GetComponent<PlayerController>();

        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        MoveToPlayer();
        StartCoroutine(FadeTo(0, 1));
    }

    bool isFirstUpdate = true;
    private void Update()
    {
        const float v = 0.5f;

        if (isFirstUpdate)
        {
            transform.position += v * this.player.transform.up;
            isFirstUpdate = false;
        }
        else transform.position += v * transform.right;

    }

    private void MoveToPlayer()
    {
        transform.position = player.transform.position;

        float rotationZ = player.transform.localEulerAngles.z + 90;

        transform.rotation =
            Quaternion.Euler(0, 0, rotationZ);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            Character controller = other.gameObject.GetComponent<Character>();
            controller.Kill();
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }

        Destroy(gameObject);
    }
}
