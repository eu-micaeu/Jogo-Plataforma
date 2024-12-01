using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class scriptNpc : MonoBehaviour
{
    public float velocidade = 2.0f;

    public float distanciaMovimento = 2.0f;

    public GameObject sonic;

    private Vector3 posicaoInicial;

    private bool movendoDireita = false;

    private Vector3 escalaOriginal;


    void Start()

    {

        posicaoInicial = transform.position;

        escalaOriginal = transform.localScale;

    }

    void Update()

    {
        if (movendoDireita)

        {

            transform.Translate(Vector3.right * velocidade * Time.deltaTime);

            if (transform.localScale.x < 0)

            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }

            if (transform.position.x >= posicaoInicial.x + distanciaMovimento)

            {
                movendoDireita = false;

            }

        }

        else

        {

            transform.Translate(Vector3.left * velocidade * Time.deltaTime);

            if (transform.localScale.x > 0)

            {

                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

            }

            if (transform.position.x <= posicaoInicial.x - distanciaMovimento)

            {

                movendoDireita = true;

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D colisao)

    {
        if (colisao.gameObject == sonic)

        {
            ContactPoint2D[] pontosDeContato = colisao.contacts;

            if (colisao.transform.position.y > transform.position.y && pontosDeContato[0].normal.y < 0)

            {

                Destroy(gameObject);

                Rigidbody2D sonicRb = sonic.GetComponent<Rigidbody2D>();

                if (sonicRb != null)

                {
                    float forcaPulo = 10.0f;

                    sonicRb.velocity = new Vector2(sonicRb.velocity.x, forcaPulo);

                }

            }

            else if (pontosDeContato[0].normal.x != 0)

            {
                Animator anim = sonic.GetComponent<Animator>();

                if (anim != null)

                    anim.SetBool("morrendo", true); 

                    Rigidbody2D sonicRb = sonic.GetComponent<Rigidbody2D>();

                {

                    sonicRb.velocity = new Vector2(sonicRb.velocity.x, 10.0f); 

                    sonicRb.isKinematic = false;  

                    sonicRb.gravityScale = 1.0f; 

                    Collider2D sonicCollider = sonic.GetComponent<Collider2D>();

                    if (sonicCollider != null)

                    {

                        sonicCollider.enabled = false;

                    }

                    Invoke("ReiniciarJogo", 1.2f);

                }

            }

        }

    }

    void ReiniciarJogo()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

    }

}
