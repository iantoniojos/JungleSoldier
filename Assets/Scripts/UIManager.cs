using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        //Pausar el tiempo meintras se abre el menu pausa
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        //Volver al juego
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void GoMainMenu()
    {
        //Ir al menu
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        //Salir del juego
        Application.Quit();
    }
}
   
