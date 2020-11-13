using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float ScoreValue = 0;
    Text score; 

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreValue += Time.deltaTime;
        score.text = "Score: " + Mathf.Round(ScoreValue);
    }
}
