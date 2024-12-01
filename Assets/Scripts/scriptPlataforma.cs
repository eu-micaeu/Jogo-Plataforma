using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{

    private Vector2 posIni;

    public float deslocamento = 1;

    private float cont = 0;

    public float largura = 1;

    public float altura = 1;

    void Start()

    {

        posIni = transform.position;

    }

    void Update()

    {

        float x = Mathf.Sin(cont) * largura;

        float y = Mathf.Cos(cont) * altura;

        transform.position = new Vector2(posIni.x + x, posIni.y + y);

        cont = cont + deslocamento * Time.deltaTime;

        if (cont > 2 * Mathf.PI)

        {
            cont = cont - 2 * Mathf.PI;

        }

    }

}
