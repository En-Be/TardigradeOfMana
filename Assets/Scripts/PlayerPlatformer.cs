using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformer : MonoBehaviour
{
    public float speed = 1;
    public float jumpforce = 1;

    private float direction = 0;
    private bool jumping = false;
    // private bool moving = false;

    private Rigidbody2D rigbod;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // float movement = 0;

        // movement = Input.GetAxis("Horizontal");
        
        // transform.position += new Vector3(movement,0,0) * Time.deltaTime * speed;

        // if(Input.GetButtonDown("Jump") && Mathf.Abs(rigbod.velocity.y) < 0.0001f)
        // {
        //     rigbod.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        // }

        
        transform.position += new Vector3(direction,0,0) * Time.deltaTime * speed;

        if(jumping && Mathf.Abs(rigbod.velocity.y) < 0.0001f)
        {
            rigbod.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            jumping = false;
        }
    }

    public void MoveLeft()
    {
        direction = -1;
    }

    public void MoveRight()
    {
        direction = 1;
    }

    public void StopMove()
    {
        direction = 0;
    }

    public void Jump()
    {
        if(Mathf.Abs(rigbod.velocity.y) < 0.0001f)
        {
            jumping = true;
        }
    }
    
}
