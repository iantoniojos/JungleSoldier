using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void BotonPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void BotonExit()
    {
        Debug.Log("Cerramos el juego");
        Application.Quit();
    }

}
