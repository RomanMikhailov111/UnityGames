using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
       //  transform.position = new Vector3(3, 3, 23); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") ;
        verticalInput = Input.GetAxis("Vertical") ;
      
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * verticalInput);
    }
}
