using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenuPausa : MonoBehaviour

{

    public void Sair()

    {

        Application.Quit(); 

    }

    public void Continuar()

    {

        Time.timeScale = 1; 

        SceneManager.UnloadSceneAsync("Pausa"); 

    }

}
