using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Rigidbody2D rb2d;
    public AudioClip shootSound;
    public AudioClip startSound;
    public static AudioSource audioSource;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(startSound);
        PlayerPrefs.SetInt("Score", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            float numerator;
            if (!float.TryParse(Type.Instance.numerator, out numerator))
            {
                numerator = 0;
            }

            float denominator;
            if (!float.TryParse(Type.Instance.denominator, out denominator))
            {
                denominator = 1;
            }

            rb2d.rotation = ((numerator * Mathf.PI / denominator) - (Mathf.PI / 2)) * Mathf.Rad2Deg;
            Type.Instance.Reset();
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        yield return new WaitForFixedUpdate();
        audioSource.PlayOneShot(shootSound);
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
