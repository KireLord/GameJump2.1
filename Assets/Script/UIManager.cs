using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class UIManager : MonoBehaviour
{
    private int totalMonedas;
    private int TotalObjetos;
    private int precioObjeto;

    [SerializeField] private TMP_Text textoMonedas;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado, corazonActivado;
    [SerializeField] private GameObject cajaTexto;
    [SerializeField] private TMP_Text textoDialogo;

    [SerializeField] private GameObject panelEquipo;


    private void Start()
    {
        Moneda.sumaMoneda += SumarMonedas;
    }

    private void SumarMonedas(int moneda)
    {
        totalMonedas += moneda;
        textoMonedas.text = totalMonedas.ToString();
    }

    public void RestaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }

    public void ActivaDesactivaCajaTextos (bool activado)
    {
        cajaTexto.SetActive (activado);
    }

    public void MostrarTextos (string texto)
    {
        textoDialogo.text = texto.ToString();
    }

    public void SumaCorazones(int indice)
    {
        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonActivado;
    }

    #region TIENDA

    public void PrecioObjeto (string objeto)
    {
        switch (objeto)
        {
            case "BotonPocionPeque":
                precioObjeto = 1;
                break;
        }
    }


    public void AdquirirObjeto(string objeto)
    {
        PrecioObjeto(objeto);

        if (precioObjeto <= totalMonedas && TotalObjetos < 3)
        {
            TotalObjetos++;
            totalMonedas -= precioObjeto;
            textoMonedas.text = totalMonedas.ToString();

            GameObject equipo = (GameObject)Resources.Load(objeto);
            Instantiate(equipo, Vector3.zero, Quaternion.identity, panelEquipo.transform);
        }
    }

    #endregion

}
