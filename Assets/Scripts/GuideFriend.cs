using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideFriend : Friend
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 editedTarget;

    [SerializeField] public float speed = 0;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private SpriteRenderer rend = null;

    public void OnEnable()
    {
        Debug.Log("GuideFriend active");
        rend.sprite = sprites[0];
    }



    void FixedUpdate()
    {
        Vector3 editedTarget = new Vector3();
        editedTarget.x = (target.position.x + Random.Range(-2f, 2f));
        editedTarget.y = (target.position.y + Random.Range(-2f, 2f));
        // Debug.Log(editedTarget);
        transform.position = Vector3.SmoothDamp(transform.position, editedTarget, ref velocity, speed);        
    } 

    public void SetTarget(Transform t)
    {
        target = t;
    }
}
