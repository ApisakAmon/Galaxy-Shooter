using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;

    public int lives = 3;
    public bool CanTripleShot = false;

    public bool CanSpeedBoost = false;

    public bool ShieldActive = false;
    [SerializeField]
    private GameObject LaserPrefab;
    [SerializeField]
    private GameObject TripleShotPrefab;
    [SerializeField]
    private GameObject ShieldGameObject;
    [SerializeField]
    private GameObject[] EngineFailure;
    [SerializeField]
    private GameObject PlayerExplosionPrefab;
    [SerializeField]
    private GameObject PlayerDamagePrefab;
    [SerializeField]
    private float FireRate = 0.25f;
    [SerializeField]
    private float CanFire = 0.0f;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private AudioClip ExplosionClip;
    private int HitCount;

    private UIManager UIManager;
    private GameManager GameManager;
    private SpawnManager SpawnManager;
    private AudioSource AudioSource;


    private void Start()
    {
        //current pos = new position




        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        SpawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (UIManager != null)
        {
            UIManager.UpdateLives(lives);
        }

        // if (SpawnManager != null)
        // {
        //     SpawnManager.StartSpawnRoutine();
        // }

        if (GameManager.isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        AudioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (isPlayerOne == true)
        {
            PlayerOneMovement();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0) && isPlayerOne == true)
            {
                Shoot();
                //pressed space and clickleft to shoot
            }
        }

        if (isPlayerTwo == true)
        {
            PlayerTwoMovement();
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && isPlayerTwo == true)
            {
                Shoot();
            }

        }



    }

    private void PlayerOneMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (CanSpeedBoost == true)
        {
            transform.Translate(Vector3.right * speed * 3f * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * 3f * verticalInput * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
        }


        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 12.4)
        {
            transform.position = new Vector3(-12.4f, transform.position.y, 0);

        }
        else if (transform.position.x < -12.4)
        {
            transform.position = new Vector3(12.4f, transform.position.y, 0);
        }

    }

    private void PlayerTwoMovement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        if (CanSpeedBoost == true)
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                transform.Translate(Vector3.down * speed * 1.5f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * speed * 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left * speed * 1.5f * Time.deltaTime);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }


        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 12.4)
        {
            transform.position = new Vector3(-12.4f, transform.position.y, 0);

        }
        else if (transform.position.x < -12.4)
        {
            transform.position = new Vector3(12.4f, transform.position.y, 0);
        }

    }

    private void Shoot()
    {

        if (Time.time > CanFire)
        {
            AudioSource.Play();
            if (CanTripleShot == true)
            {
                Instantiate(TripleShotPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(LaserPrefab, transform.position + new Vector3(0, 1.4f, 0), Quaternion.identity);

            }
            CanFire = Time.time + FireRate;

        }



    }

    //Start Powerup
    public void TripleShotPowerOn()
    {
        CanTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        CanTripleShot = false;
    }

    public void SpeedBoostPowerOn()
    {
        CanSpeedBoost = true;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        CanSpeedBoost = false;
    }

    public void EnableShield()
    {
        ShieldActive = true;
        ShieldGameObject.SetActive(true);
        StartCoroutine(DisableShield());
    }

    public IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(10f);
        ShieldActive = false;
        ShieldGameObject.SetActive(false);
    }
    //End Powerup
    public void Damage()
    {

        if (ShieldActive == true)
        {
            ShieldActive = false;
            ShieldGameObject.SetActive(false);
            return;
        }


        lives--;
        HitCount++;
        UIManager.UpdateLives(lives);
        if (HitCount == 1)
        {
            EngineFailure[0].SetActive(true);
        }
        else if (HitCount == 2)
        {
            EngineFailure[1].SetActive(true);
        }

        if (lives < 1)
        {
            Destroy(this.gameObject);
            Instantiate(PlayerExplosionPrefab, transform.position, Quaternion.identity);
            GameManager.GameOver = true;
            UIManager.BestScoreCheck();
            UIManager.ShowTitleScreen();
            AudioSource.PlayClipAtPoint(ExplosionClip, Camera.main.transform.position, 1f);
            
        }


    }

}