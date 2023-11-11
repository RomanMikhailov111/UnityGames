using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; 
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody.AddForce(Vector3.up * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
