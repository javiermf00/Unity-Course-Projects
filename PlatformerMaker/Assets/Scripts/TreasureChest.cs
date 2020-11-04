using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public GameObject[] RandomPrefabs;

    private int randomPrefabNum;
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCollider.enabled = false;

            myAnimator.SetBool("Collision", true);

            randomPrefabNum = Random.Range(0, 2);
            Instantiate(RandomPrefabs[randomPrefabNum], transform.position + (transform.right), transform.rotation);
        }
        
    }
}
