using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float speed = 2f;           
    public float wanderRadius = 5f;    
    public float changeInterval = 2f;  

    private Vector3 targetPosition;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        UpdateTargetPosition();
        timer = changeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            UpdateTargetPosition();
            timer = changeInterval;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void UpdateTargetPosition()
    {
        float x = Random.Range(-wanderRadius, wanderRadius);
        float z = Random.Range(-wanderRadius, wanderRadius);
        targetPosition = new Vector3(x, 0, z) + transform.position;
    }
}
