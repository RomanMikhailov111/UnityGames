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
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRigidBody.AddForce(FocalPoint.transform.forward * forwardInput * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPowerUp = true;
            Destroy(other.gameObject);
        }
    }
}
