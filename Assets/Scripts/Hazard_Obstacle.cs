using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Obstacle : Hazard
{
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private SpriteRenderer rend = null;
    
    public void OnEnable()
    {
        Debug.Log("Hazard_Obstacle active");
        rend.sprite = sprites[0];
    }
}
