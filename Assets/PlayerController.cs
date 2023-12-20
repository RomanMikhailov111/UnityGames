using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5.0f;
    private Rigidbody playerRigidBody;
    private GameObject FocalPoint;
    public bool isPowerUp;
    public float PowerUpForce = 15.0f;
    private Vector3 StartPos;
    void Start()
    {
        StartPos = transform.position;
        playerRigidBody = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRigidBody.AddForce(FocalPoint.transform.forward * forwardInput * Speed);
        
        if (transform.position.y < -10f)
        {
            transform.position = StartPos;
            playerRigidBody.velocity = Vector3.zero;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUp());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isPowerUp == true) 
            {
                Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 AwayFromPlayer = (collision.gameObject.transform.position - transform.position);
                EnemyRigidbody.AddForce(AwayFromPlayer * PowerUpForce, ForceMode.Impulse);
            }
        }
    }
    private IEnumerator PowerUp ()
    {
        yield return new WaitForSeconds(3f);
        isPowerUp = false;
    }
}
