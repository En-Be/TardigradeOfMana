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
            StartCoroutine("Life");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("collect");
            // other.GetComponent<Player>().mana += manaAmount;
            other.GetComponent<Player>().Healed(manaAmount);
            Destroy(gameObject);
        }
    }

    private IEnumerator Life()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
