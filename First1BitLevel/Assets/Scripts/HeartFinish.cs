﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager.instance.TextoGanador();
        }
    }
}
