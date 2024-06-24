using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManaging : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    public void CompareNumberGame()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OrderNumberGame()
    {
        SceneManager.LoadScene(2);
    }

    public void ComposeNumberGame()
    {
        SceneManager.LoadScene(3);
    }
}
