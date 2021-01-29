using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public int MapSelect;
    public int TeamSelect;

    public void Map1()
    {
        MapSelect = 1;
    }


    public void PlayGame()
    {
        switch (MapSelect)
        {
            case 1:
                SceneManager.LoadScene(2);
                break;
          
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT Main Menu confirm");
        Application.Quit();
    }
}
