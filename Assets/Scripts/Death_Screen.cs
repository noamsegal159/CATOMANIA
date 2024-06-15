using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Screen : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI MaxScore;
    public void PlayCATOMANIA() //New Game
    {
        SceneManager.LoadScene("CATOMANIA"); 
    }
    public void LoadMainMenu() //Main Menu
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void Start()
    {
        //calculating max score and printing it on screen
        if (StaticData.maxScore < StaticData.score)
            StaticData.maxScore = StaticData.score;
        Score.text = "Score = " + StaticData.score;
        MaxScore.text = "Max Score = " + StaticData.maxScore;
    }
}
