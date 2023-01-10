using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    Rigidbody2D myRigidBody;
    PlayerMovement player; 
    float xSpeed;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    
    void Update()
    {
        FlipSprite();
        myRigidBody.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
       if(other.tag == "Enemies")
       {
            Destroy(other.gameObject);
       }
       Destroy(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);
    }

    void FlipSprite()
    {
        if(xSpeed < 0.01f)
            transform.localScale = new Vector3(-0.07863811f,0.07132933f,1);

    }
}
