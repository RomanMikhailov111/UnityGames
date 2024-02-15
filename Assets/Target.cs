using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int ScoreValue = 1;

    public float StartForceMin = 12f;
    public float StartForceMax = 16f;
    public float StartTorqueMin = -10f;
    public float StartTorqueMax = 10f;
    private Rigidbody TargetRigidBody;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        TargetRigidBody = GetComponent<Rigidbody>();
        TargetRigidBody.AddForce(Vector3.up * Random.Range(StartForceMin, StartForceMax), ForceMode.Impulse);
        TargetRigidBody.AddTorque(GenerateTorqueValue(), GenerateTorqueValue(), GenerateTorqueValue(), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }
    private float GenerateTorqueValue ()
    {
        return Random.Range(StartTorqueMin, StartTorqueMax);
    }

    private void OnMouseDown()
    {
        gameManager.AddScore(ScoreValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
