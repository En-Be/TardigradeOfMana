using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        targetPos.z = -10;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
        gameObject.transform.position = smoothPos;
    }
}
