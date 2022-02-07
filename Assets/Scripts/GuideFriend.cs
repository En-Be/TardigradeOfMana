using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideFriend : Friend
{
    [SerializeField] private Transform target = null;
    [SerializeField] public float speed = 0;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private bool pressing = false;
    [SerializeField] private float receiveRate = 0;
    [SerializeField] private PlayerAgent player = null;

    [SerializeField] private Sprite[] sprite = null;
    [SerializeField] private SpriteRenderer rend = null;

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, speed);
    }

    
}
