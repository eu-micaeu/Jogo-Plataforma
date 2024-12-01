using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptCamera : MonoBehaviour

{

    public GameObject Pc;

    public float offsetY;

    private AudioSource som;

    void Start()

    {

        offsetY = 2;

        som = GetComponent<AudioSource>();

        if (som != null)

        {

            som.Play();

        }

        else

        {

            Debug.LogWarning("AudioSource não encontrado!");

        }

    }

    void Update()

    {

        transform.position = new Vector3(Pc.transform.position.x, Pc.transform.position.y + offsetY, -10);


        if (Input.GetKeyDown(KeyCode.Escape))

        {

            Time.timeScale = 0;

            SceneManager.LoadScene("Pausa", LoadSceneMode.Additive); 

        }

    }

}
