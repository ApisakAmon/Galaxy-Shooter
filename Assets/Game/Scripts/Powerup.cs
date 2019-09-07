using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private int powerupID;

    [SerializeField]
    private AudioClip PowerupSound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //log collide with
        Debug.Log("Collided with:" + other.name);

        if (other.tag == "Player")
        {

            //get Player component
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                AudioSource.PlayClipAtPoint(PowerupSound,Camera.main.transform.position, 1f);
                if (powerupID == 0)
                {
                    //enable triple shot
                    player.TripleShotPowerOn();
                    
                }
                if (powerupID == 1)
                {
                    //enable speed boost 
                    player.SpeedBoostPowerOn();
                    
                }
                if (powerupID == 2)
                {
                    //enable Shield
                    player.EnableShield();
                    
                }
                

            }
            //on collided
            Destroy(this.gameObject);


        }
    }
}
