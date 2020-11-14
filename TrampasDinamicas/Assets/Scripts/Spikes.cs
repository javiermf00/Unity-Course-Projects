using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Animator myAnim;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
    }

    void DealDamage()
    {
        boxCollider.enabled = true;
    }

    void NotDealDamage()
    {
        boxCollider.enabled = false;
    }


    /*
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.Respawn();
        }
    }
    */

}
