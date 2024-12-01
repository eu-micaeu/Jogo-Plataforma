using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPc : MonoBehaviour
{
    public LayerMask mascara;

    public GameObject pe;

    private Rigidbody2D rbd;

    private Animator anim;

    public float vel;

    public float pulo;

    private bool noChao;

    private bool dir = true;

    void Start()
    {

        pulo = 550;

        vel = 5;

        rbd = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }

    void Update()

    {
        float x = Input.GetAxis("Horizontal");

        rbd.velocity = new Vector2(x * vel, rbd.velocity.y);

        if (x == 0)

        {

            anim.SetBool("movendo", false);

        }

        else

        {

            anim.SetBool("movendo", true);

        }

        if (Input.GetKeyDown(KeyCode.Space) && noChao)

        {

            rbd.AddForce(new Vector2(0, pulo));

            anim.SetBool("pulando", true);  

        }

        if (x > 0 && !dir || x < 0 && dir)

        {

            transform.Rotate(new Vector2(0, 180));

            dir = !dir;

        }

        RaycastHit2D hit = Physics2D.Raycast(pe.transform.position, Vector2.down, 0.3f, mascara);

        if (hit.collider != null)

        {
            noChao = true;

            anim.SetBool("pulando", false);

            transform.parent = hit.collider.transform;

        }

        else

        {

            noChao = false;

            anim.SetBool("pulando", true); 

            transform.parent = null;

        }

        if (transform.position.y < -10)

        {

            Application.LoadLevel(Application.loadedLevel);

        }

    }

}
