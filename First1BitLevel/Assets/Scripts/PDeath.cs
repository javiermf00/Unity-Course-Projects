﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Manager.instance.Respawn();
        }
    }
}
