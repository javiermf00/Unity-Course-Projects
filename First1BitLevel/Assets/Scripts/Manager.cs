using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public Transform RespawnPoint;
    public GameObject playerPrefab;
    public GameObject TextFinal;

    public void TextoGanador()
    {
        TextFinal.SetActive(true);
    }


    private void Awake()
    {
        instance = this;
    }
    public void Respawn()
    {
        Instantiate(playerPrefab, RespawnPoint.position, Quaternion.identity);
    }

}
