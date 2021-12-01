using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaEmitter : MonoBehaviour
{
    public GameObject collectible;
    public float emitAmount;
    public float life;

    private IEnumerator coroutine;

    public void Start()
    {
        
    }

    public void Emit()
    {
        StartCoroutine("Emitting");
    }

    private IEnumerator Emitting()
    {
        Debug.Log("emit");
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("Emitting");
        GameObject manaBit = Instantiate(collectible, transform.position, transform.rotation);
        manaBit.GetComponent<Collectible>().manaAmount = emitAmount;
        manaBit.GetComponent<Collectible>().life = life;
    }
}
