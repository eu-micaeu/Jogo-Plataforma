using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    private AudioSource som;

    void Start()

    {
        som = GetComponent<AudioSource>();
        
        som.Play();
        

    }

    public void Iniciar()

    {

        SceneManager.LoadScene("Jogo");

    }

    public void Sair()

    {

        Application.Quit(); 

    }

}
