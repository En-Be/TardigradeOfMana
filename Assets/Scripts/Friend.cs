using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] protected bool isFriend = true;

    public virtual bool IsFriend()
    {
        return isFriend;
    }

    public virtual void IsFriend(bool b)
    {
        isFriend = b;
        Debug.Log($"isFriend in parent == {isFriend}");
    }
}
