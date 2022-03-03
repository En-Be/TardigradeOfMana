using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaAdjustmentRing : MonoBehaviour
{
    public Transform t;

    public void Dead()
    {
        Debug.Log("should destroy ring now");
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        transform.position = t.position;
    }
}
