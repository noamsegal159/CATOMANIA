using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour
{
    public void PlayCATOMANIA() //play game
    {
        SceneManager.LoadScene("CATOMANIA");
    }

    public void LoadInstructions() //goto instructions
    {
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame() //quit
    {
        Application.Quit();
    }
}
