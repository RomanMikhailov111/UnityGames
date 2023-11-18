using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    // Start is called before the first frame update
    public float jumpForce;
    public float gravityModifier;
    public bool isGround;
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround==true)
        {
            isGround = false;
            playerRigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        isGround = true;
    } 
   
            
      
   
}
