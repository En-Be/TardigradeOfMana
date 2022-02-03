using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float manaAmount;
    public float life;
    public bool dies;

    public void Start()
    {
        if(dies)
        {
            StartCoroutine("Live");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {   
            PlayerAgent player = other.GetComponent<PlayerAgent>();
            if(player.CurrentMana() != player.MaxMana())
            {
                Debug.Log("collect");
                player.AdjustMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator Live()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
