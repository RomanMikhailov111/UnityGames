using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < - offset)
        {
            transform.position = new Vector3 (-offset , transform.position.y, transform.position.z);
           
        }
        if (transform.position.x > offset)
        {
            transform.position = new Vector3 (offset , transform.position.y, transform.position.z);
           
        }
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
   
        
    }
}
