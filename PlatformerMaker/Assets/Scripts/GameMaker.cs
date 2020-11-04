using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaker : MonoBehaviour
{
    public GameObject[] PrefabsToInstantiate;
    public GameObject PrefabsButtons;
    public Transform layout;
    public SpriteRenderer preview;
    public GameObject[] playingComponents;

    int id;

    public static bool playing;

    private void Start()
    {
        for(int i = 0; i < PrefabsToInstantiate.Length; i++)
        {
            int u = i;
            var t = Instantiate(PrefabsButtons, layout);
            t.GetComponent<Image>().sprite = PrefabsToInstantiate[u].GetComponent<SpriteRenderer>().sprite;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                id = u;
                preview.sprite = PrefabsToInstantiate[u].GetComponent<SpriteRenderer>().sprite;
            });
        }
    }

    public void TogglePlaying()
    {
        playing = !playing;
        preview.enabled = !playing;
        for(int j = 0; j < playingComponents.Length; j++)
        {
            playingComponents[j].SetActive(!playing);
        }
    }

    private void Update()
    {
        if (playing)
        {
            return;
        }
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
            

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        preview.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(PrefabsToInstantiate[id].gameObject, pos, Quaternion.identity);
        }
    }

}
