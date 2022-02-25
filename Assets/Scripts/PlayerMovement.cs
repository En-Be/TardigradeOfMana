using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick = null;
    [SerializeField] private float speed = 0;
    private Rigidbody2D rigbod;
    public bool isBouncing = false;

    [SerializeField] private GameObject[] spawnPoints = null;
    [SerializeField] private string[] spawnFrom = null;
    [SerializeField] private CameraFollow cam = null;

    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
        if(GameManager.Instance.CurrentLevel != GameManager.Instance.PreviousLevel)
        {
            MoveToSpawnPoint();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isBouncing)
        {
            rigbod.AddForce(new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed), ForceMode2D.Force);
        }
    }

    public void Collided(Vector2 v)
    {
        isBouncing = true;
        Debug.Log(v);
        rigbod.AddForce(v, ForceMode2D.Impulse);
        Invoke("StopBounce", 0.3f);
    }

    void StopBounce()
    {
        isBouncing = false;
    }

    private void MoveToSpawnPoint()
    {
        int i = Array.IndexOf(spawnFrom, GameManager.Instance.PreviousLevel);
        // Debug.Log(i);
        transform.position = spawnPoints[i].transform.position;
        cam.SnapTo();
    }
}
