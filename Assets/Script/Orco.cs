using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orco : MonoBehaviour
{
    public Transform personaje;
    public Transform [] puntosRuta;
    private int indiceRuta;
    private NavMeshAgent agente;
    private bool objetivoDetectado;
    private SpriteRenderer sprite;
    private Transform objetivo;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agente = GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    private void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);
        if(this.transform.position == puntosRuta[indiceRuta].position)
        {
            if(indiceRuta < puntosRuta.Length - 1)
            {
                indiceRuta++;
            }
            else if (indiceRuta == puntosRuta.Length -1) 
            { 
                indiceRuta = 0;
            }
        }


        if (distancia < 3)
        {
            objetivoDetectado = true;
        }

        MovimientoOrco(objetivoDetectado);
        RotarOrco();
        
    }

    void MovimientoOrco (bool esDetectado)
    {
        if (esDetectado) 
        {
            agente.SetDestination(personaje.position);
            objetivo = personaje;
        }
        else
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            objetivo = puntosRuta[indiceRuta];
        }
    }

    void RotarOrco ()
    {
        if(this.transform.position.x > objetivo.position.x)
        {
            //sprite.flipX= true;
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            //sprite.flipX= false;
            transform.localScale = new Vector2(1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Ataca");
        }
    }
}
