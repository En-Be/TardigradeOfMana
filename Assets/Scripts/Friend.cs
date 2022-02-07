using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] private bool isFriend = true;

    public bool IsFriend()
    {
        return isFriend;
    }

    public void IsFriend(bool b)
    {
        isFriend = b;
    }
}
