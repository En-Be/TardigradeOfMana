using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hazard : MonoBehaviour
{
    public bool isHazard = true;
    public int damage;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if(isHazard && other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.mana -= damage;
        }
    }
}
