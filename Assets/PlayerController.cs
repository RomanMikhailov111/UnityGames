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
    public ParticleSystem ExplosionParticle;
    public ParticleSystem DirtParticle;
    public AudioClip JumpSound;
    public AudioClip CrashSound;
    public AudioSource PlayerAudio;
    void Start()
    {
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true && isGameOver == false)
        {
            PlayerAudio.PlayOneShot(JumpSound, 1.0f);
            isGround = false;
            playerRigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            DirtParticle.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGameOver)
            {
                DirtParticle.Play();
            }
            isGround = true;
        }
        else if ((collision.gameObject.CompareTag("Obstacle"))) 
        {
            PlayerAudio.PlayOneShot(CrashSound, 1.0f); 
            isGameOver = true;
            playerAnimator.SetBool("Death_b", true);
            DirtParticle.Stop();
            playerAnimator.SetInteger("DeathType_int", 1);
            ExplosionParticle.Play();
            Debug.Log("GameOver");
        }
    } 
   
            
      
   
}
