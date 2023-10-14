using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode keyCode;
    public float speed;
    public float rotateSpeed;
    public float horizontalInput;
    public float verticalInput;
    public string inputID = null;
    // Start is called before the first frame update
    void Start()
    {
       //  transform.position = new Vector3(3, 3, 23); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"+ inputID) ;
        verticalInput = Input.GetAxis("Vertical" + inputID) ;
      
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed * verticalInput);

        if (Input.GetKeyDown(keyCode)) 
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
            
        }
    }
}
