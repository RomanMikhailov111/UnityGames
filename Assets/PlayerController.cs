using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5.0f;
    private Rigidbody playerRigidBody;
    private GameObject FocalPoint;
    public GameObject PowerUpIndicator;
    public PowerUpType CurrentPowerUp = PowerUpType.None;
    public float PowerUpForce = 15.0f;
    private Vector3 StartPos;
    public Rocket RocketPrefab;
    private Coroutine PowerUpCoroutine;
    private bool isPowerUp;
    void Start()
    {
        StartPos = transform.position;
        playerRigidBody = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpIndicator.transform.position = new Vector3(transform.position.x,transform.position.y-0.5f,transform.position.z);

        float forwardInput = Input.GetAxis("Vertical");
        playerRigidBody.AddForce(FocalPoint.transform.forward * forwardInput * Speed);
        
        if (transform.position.y < -10f)
        {
            transform.position = StartPos;
            playerRigidBody.velocity = Vector3.zero;
        }

        if (CurrentPowerUp == PowerUpType.Rocket)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                LaunchRockets();
            }
        }
    }

    private void LaunchRockets()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            Rocket TempRocket = Instantiate(RocketPrefab,transform.position+Vector3.up,Quaternion.identity);
            TempRocket.Fire(enemy.transform);
        }

        PowerUpEnable(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            CurrentPowerUp = other.gameObject.GetComponent<PowerUp>().type;
            Destroy(other.gameObject);

            if (PowerUpCoroutine != null)
            {
                StopCoroutine(PowerUpCoroutine);
            }

            PowerUpCoroutine=StartCoroutine(PowerUp());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (CurrentPowerUp == PowerUpType.PushBack) 
            {
                Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 AwayFromPlayer = (collision.gameObject.transform.position - transform.position);
                EnemyRigidbody.AddForce(AwayFromPlayer * PowerUpForce, ForceMode.Impulse);
            }
        }
    }
    private IEnumerator PowerUp ()
    {
        PowerUpEnable(true);
        yield return new WaitForSeconds(3f);
        PowerUpEnable(false);
    }
    private void PowerUpEnable(bool isEnable)
    {
        isPowerUp = isEnable;
        PowerUpIndicator.SetActive(isEnable);
        if (isEnable == false)
        {
            CurrentPowerUp = PowerUpType.None;
        }
    }
}
