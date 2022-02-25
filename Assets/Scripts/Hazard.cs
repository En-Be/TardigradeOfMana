using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hazard : MonoBehaviour
{
    [SerializeField] private bool isHazard = true;
    [SerializeField] private int damage = 0;
    [SerializeField] private Collider2D col;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(isHazard && collider.tag == "Player")
        {
            PlayerAgent player = collider.GetComponent<PlayerAgent>();
            player.AdjustMana(damage * -1);
            // PlayerMovement playerCol = collider.GetComponent<PlayerMovement>();
            // playerCol.Collided(collision);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            float bounce = -6f; //amount of force to apply
            collision.gameObject.GetComponent<PlayerMovement>().Collided(collision.contacts[0].normal * bounce);
        }
    }

    public bool IsHazard()
    {
        return isHazard;
    }

    public void IsHazard(bool b)
    {
        isHazard = b;
        col.enabled = false;
    }
}
