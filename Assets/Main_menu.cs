using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene(0);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}