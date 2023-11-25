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
    public bool isGameOver;
    public Animator playerAnimator;
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true && isGameOver == false)
        {
            isGround = false;
            playerRigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        else if ((collision.gameObject.CompareTag("Obstacle"))) 
        { 
            isGameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            Debug.Log("GameOver");
        }
    } 
   
            
      
   
}
