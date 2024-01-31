using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public enum ObjetosEquipo
    {
        SaludPeque,
        SaludGran,
        Velocidad
    };

    [SerializeField] ObjetosEquipo objetosEquipo;

    public void UsarObjeto()
    {
        Personaje personaje = GameObject.FindObjectOfType<Personaje>();

        switch(objetosEquipo)
        {
            case ObjetosEquipo.SaludPeque:
                Debug.Log("Cura un punto de salud");
                personaje.SumaVida();
                break;
                case ObjetosEquipo .SaludGran:
                Debug.Log("Cura dos puntos de salud");
                break;
            case ObjetosEquipo.Velocidad:
                Debug.Log("Aumenta la velocidad del personaje");
                break;
        }
        Destroy(this.gameObject);
    }
}
