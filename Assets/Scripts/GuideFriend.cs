using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideFriend : Friend
{
    [SerializeField] private Transform target = null;
    [SerializeField] public float speed = 0;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private SpriteRenderer rend = null;

    public override void IsFriend(bool b)
    {
        base.IsFriend(b);
        Debug.Log($"isFriend in child == {isFriend}");
        if(isFriend == true)
        {
            Debug.Log("GuideFriend active");
            // rend = GetComponent<SpriteRenderer>();
            rend.sprite = sprites[0];
        }
    }

    void FixedUpdate()
    {
        if(isFriend)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, speed);
        }

    } 

    public void SetTarget(Transform t)
    {
        target = t;
    }
}
