using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hazard : MonoBehaviour
{
    [SerializeField] private bool isHazard = true;
    [SerializeField] private int damage = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if(isHazard && other.tag == "Player")
        {
            PlayerAgent player = other.GetComponent<PlayerAgent>();
            player.AdjustMana(damage * -1);
        }
    }

    public bool IsHazard()
    {
        return isHazard;
    }

    public void IsHazard(bool b)
    {
        isHazard = b;
    }
}
