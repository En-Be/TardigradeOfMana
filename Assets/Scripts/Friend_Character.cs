using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend_Character : Friend
{
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private SpriteRenderer rend = null;
    
    public void OnEnable()
    {
        Debug.Log("CharacterFriend active");
        rend.sprite = sprites[0];
    }
}
