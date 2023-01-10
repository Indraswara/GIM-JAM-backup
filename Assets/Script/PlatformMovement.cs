using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 1f;
    public int patrolDestination = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < .2f)
        {
            patrolDestination ++;
            if(patrolDestination >= patrolPoints.Length)
                patrolDestination = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            other.gameObject.transform.SetParent(transform);   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
            other.gameObject.transform.SetParent(null);   
    }
}
