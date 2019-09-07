using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyAI : MonoBehaviour
{

    [SerializeField]
    private GameObject EnemyExplosionPrefab;

    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private AudioClip Clip;
    private UIManager UIManager;
    void Start()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        float randomX = Random.Range(-7f, 7f);
        if (transform.position.y < -7)
        {
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(Clip,Camera.main.transform.position, 1f);
        if (other.tag == "Laser")
        {

            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }

            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            UIManager.UpdateScores();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
            

        }

        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
