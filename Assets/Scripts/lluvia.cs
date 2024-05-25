
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para manejar la lluvia en el juego
public class lluvia : MonoBehaviour
{public GameObject lluviaobj;
public GameObject sonidolluvia; // Asegúrate de que este objeto tenga un componente AudioSource con el clip de sonido de la lluvia
private AudioSource sonido; // Para controlar la reproducción del sonido
private float tiempotranscurrido = 0;
public bool lluviaactiva = false;

void Start()
{
    // Obtén el componente AudioSource del objeto sonidolluvia
    sonido = sonidolluvia.GetComponent<AudioSource>();
}

public void ActivarLluvia()
{
    lluviaactiva = true;
}

void Update()
{
    if (lluviaactiva)
    {
        if (tiempotranscurrido <= 5f)
        {
            // Mientras el tiempo transcurrido sea <= 5 segundos, activar la lluvia y el sonido
            lluviaobj.SetActive(true);
            if (!sonido.isPlaying)
            {
                sonido.Play();
            }
            tiempotranscurrido += Time.deltaTime;
        }
        else
        {
            // Después de 5 segundos, desactivar la lluvia y el sonido, y detener el temporizador
            lluviaobj.SetActive(false);
            if (sonido.isPlaying)
            {
                sonido.Stop();
            }
            lluviaactiva = false;
            // Opcional: Resetear tiempotranscurrido si quieres que la lluvia pueda ser reactivada
            tiempotranscurrido = 0;
        }
    }
}
}