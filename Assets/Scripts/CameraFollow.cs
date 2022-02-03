using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth;

    void Start()
    {
        SnapTo();
    }

    // Start is called before the first frame update
    public void SnapTo()
    {
        Vector3 targetPos = target.position;
        targetPos.z = -10;
        gameObject.transform.position = targetPos;
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
