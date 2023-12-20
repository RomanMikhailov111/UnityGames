using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    private Rigidbody enemyRigidbody;
    private GameObject Player;
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = (Player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(LookDirection * Speed);
    }
}
