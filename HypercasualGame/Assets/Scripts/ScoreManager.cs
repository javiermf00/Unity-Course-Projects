using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static float ScoreValue = 0;
    Text score;
    public bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true)
        {
            ScoreValue += Time.deltaTime;
            score.text = "Score: " + Mathf.Round(ScoreValue);
        }

    }

    public void GameEnded()
    {
        isPlaying = false;
        Invoke("Restart", 2.5f);
        ScoreValue = 0;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
