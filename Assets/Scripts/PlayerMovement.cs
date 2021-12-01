using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    private Rigidbody2D rigbod;

    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigbod.AddForce(new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed), ForceMode2D.Force);
    }
}
