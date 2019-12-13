using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalMenu : MonoBehaviour
{
    public void triggerPrincipalMenu(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Menu");
                break;
            case (1):
                SceneManager.LoadScene("Game2");
                break;
            case (2):
                Application.Quit();
                break;
        }
    }
}