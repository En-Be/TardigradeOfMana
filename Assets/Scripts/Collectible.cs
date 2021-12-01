﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float manaAmount;
    public float life;

    public void Start()
    {
        StartCoroutine("Life");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collect");
        other.GetComponent<Player>().mana += manaAmount;
        Destroy(gameObject);
    }

    private IEnumerator Life()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
