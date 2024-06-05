using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemy : MonoBehaviour
{
    public int health = 1;
    public static float speedIncreaser = 1.0f;
    public GameObject explosionPrefab;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float rotation = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg + 90.0f;
        rb.rotation = rotation;
        speedIncreaser = 1.0f;
    }

    private void Update()
    {
        rb.velocity = transform.up * 0.25f * speedIncreaser;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health--;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 100);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "Player")
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
