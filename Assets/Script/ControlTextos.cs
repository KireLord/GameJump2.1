using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextos : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string[] arrayTextos;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private Personaje personaje;

    private int indice;

    private void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player").GetComponent<Personaje>();
    }

    private void OnMouseDown()
    {
        float distancia = Vector2.Distance(this.gameObject.transform.position, personaje.transform.position);
        if (distancia <= 2)
        {
            uIManager.ActivaDesactivaCajaTextos(true);
            personaje.ChequearSiHablo(true);
            ActivaCartel();
        }
    }

    void ActivaCartel()
    {
        if (indice < arrayTextos.Length) 
        {
            uIManager.MostrarTextos(arrayTextos[indice]);
            indice++;
        }
        else 
        {
            uIManager.ActivaDesactivaCajaTextos(false);
            personaje.ChequearSiHablo(false);
        }

    }
}
