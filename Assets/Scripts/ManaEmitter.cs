using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaEmitter : MonoBehaviour
{
    public GameObject collectible;
    public float emitAmount;
    public float size;
    public float rate;
    public float life;
    public float velocity;

    private IEnumerator coroutine;

    public void Start()
    {
        Emit();
    }

    public void Emit()
    {
        StartCoroutine("Emitting");
    }

    private IEnumerator Emitting()
    {
        Debug.Log("emit");
        GameObject manaBit = Instantiate(collectible, transform.position,transform.rotation);
        manaBit.GetComponent<Collectible>().manaAmount = emitAmount;
        manaBit.GetComponent<Collectible>().dies = true;
        manaBit.GetComponent<Collectible>().life = life;
        Vector3 newSize = new Vector3(size, size, 1);
        manaBit.transform.localScale = newSize;
        manaBit.transform.Rotate(0, 0, Direction());
        manaBit.GetComponent<Rigidbody2D>().AddRelativeForce(manaBit.transform.up * velocity);
        yield return new WaitForSeconds(rate);
        Emit();
    }

    private float Direction()
    {
        return Random.Range(-40, 40);
    }
}
