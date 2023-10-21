using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    public float offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > offset)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -offset)
        {
            Destroy(gameObject);
        }
    }
}