using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Transform Target;
    private float Speed = 15.0f;
    private bool IsEnable;
    private float RocketStrength = 15.0f;
    private float AliveTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnable == true && Target != null)
        {
            Vector3 MoveDirection = (Target.position - transform.position).normalized;
            transform.position += MoveDirection * Speed * Time.deltaTime;
            transform.LookAt(Target); 
        }
    }

    public void Fire(Transform newTarget)
    {
      Target = newTarget;
        IsEnable = true;
        Destroy(gameObject, AliveTimer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Target != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //TODO:write Enemy collision logic
            }
        }
    }
}
