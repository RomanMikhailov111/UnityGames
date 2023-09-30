using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(5, 6, 9); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 dir = Vector3.forward;
        transform.Translate(dir * Time.deltaTime * speed * horizontalInput);
    }
}
