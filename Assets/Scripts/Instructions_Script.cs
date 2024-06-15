using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions_Script : MonoBehaviour
{
   public void LoadMainMenu() //move to the main menu
   {
        SceneManager.LoadScene("MainMenu");
   }
}
