using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasitionScript : MonoBehaviour
{
    public void Continuar()
    {
        SceneManager.LoadScene(3);
    }
}
