/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para manejar las partículas de rayos
public class rayo : MonoBehaviour
{
    public GameObject rayoaobj;
public GameObject sonidorayo; // Asegúrate de que este objeto tenga un componente AudioSource con el clip de sonido de la lluvia
private AudioSource sonido; // Para controlar la reproducción del sonido
private float tiempotranscurrido = 0;
public bool rayoactivo = false;

void Start()
{
    // Obtén el componente AudioSource del objeto 
    sonido = sonidorayo.GetComponent<AudioSource>();
}

public void Truena()
{
    rayoactivo = true;
}

void Update()
{
    if (rayoactivo)
    {
        if (tiempotranscurrido <= 5f)
        {
            // Mientras el tiempo transcurrido sea <= 5 segundos, activar la lluvia y el sonido
            rayoaobj.SetActive(true);
            if (!sonido.isPlaying)
            {
                sonido.Play();
            }
            tiempotranscurrido += Time.deltaTime;
        }
        else
        {
            // Después de 5 segundos, desactivar la lluvia y el sonido, y detener el temporizador
            rayoaobj.SetActive(false);
            if (sonido.isPlaying)
            {
                sonido.Stop();
            }
            rayoactivo = false;
            // Opcional: Resetear tiempotranscurrido si quieres que la lluvia pueda ser reactivada
            tiempotranscurrido = 0;
        }
    }
}
}
