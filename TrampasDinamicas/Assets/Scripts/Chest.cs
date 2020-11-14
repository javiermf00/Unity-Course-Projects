using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    static Animator chAnim;

    // Start is called before the first frame update
    void Start()
    {
        chAnim = GetComponent<Animator>();
    }

    public static void OpenChest()
    {
        chAnim.SetTrigger("Open");
    }
}
