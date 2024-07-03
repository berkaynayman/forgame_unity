using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rigigbody2D;
    public Vector2 lastVelocity;

    public Movement LeftPlayer;
    public Movement RightPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rigigbody2D = GetComponent<Rigidbody2D>();    
    }

    public void SendBallInRandomDirection()
    {
        rigigbody2D.velocity = Vector3.zero;
        rigigbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigigbody2D.isKinematic = false;
        rigigbody2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5f;
        lastVelocity = rigigbody2D.velocity;

        LeftPlayer.speed = LeftPlayer.defaultSpeed;
        RightPlayer.speed = RightPlayer.defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SendBallInRandomDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigigbody2D.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        lastVelocity = rigigbody2D.velocity * 1.1f;
        LeftPlayer.speed *= 1.1f;
        RightPlayer.speed *= 1.1f; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            Debug.Log("Left Plater Scored");
        }
        if (transform.position.x < 0)
        {
            Debug.Log("Right Plater Scored");
        }
        SendBallInRandomDirection();
    }
}


