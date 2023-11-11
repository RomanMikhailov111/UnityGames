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
    public float offsetZmin; 
    public float offsetZmax; 
    public GameObject[] projecttile;
    public int index;
    public SpawnManager[] spawnManager;
    void Start()
    {
        /*        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();*/
        spawnManager = FindObjectsOfType<SpawnManager>();
    
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
        if (transform.position.z < offsetZmin)
        {
            transform.position = new Vector3 (transform.position.x , transform.position.y, offsetZmin);
           
        }
        if (transform.position.z > offsetZmax)
        {
            transform.position = new Vector3 (transform.position.x , transform.position.y, offsetZmax);
           
        }
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index = Random.Range(0, projecttile.Length);    
            Instantiate(projecttile[index], transform.position, projecttile[index].transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        { 
            for (int i = 0; i < spawnManager.Length; i++)
            {
                spawnManager[i].gameOver = true;
            }
    
            Destroy(gameObject);
        }
        
        
    }
}
