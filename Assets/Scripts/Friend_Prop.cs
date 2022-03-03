using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend_Prop : Friend
{
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private SpriteRenderer rend = null;
    
    public void OnEnable()
    {
        Debug.Log("PropFriend active");
        rend.sprite = sprites[0];
    }
}
