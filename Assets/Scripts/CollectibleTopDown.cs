using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleTopDown : MonoBehaviour
{
    public PlayerTopDown player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        player.collected += 1;
        Destroy(gameObject);
    }
}
