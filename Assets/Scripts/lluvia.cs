using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lluvia : MonoBehaviour
{
    public GameObject lluviaobj;
    public GameObject sonidolluvia; // Opcional: para reproducir un sonido de lluvia
    private float tiempotranscurrido = 0;
    public bool lluviaactiva = false;

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
                // Mientras el tiempo transcurrido sea <= 3 segundos, activar la lluvia
                lluviaobj.SetActive(true);
                tiempotranscurrido += Time.deltaTime;
            }
            else
            {
                // Después de 3 segundos, desactivar la lluvia y detener el temporizador
                lluviaobj.SetActive(false);
                lluviaactiva = false;
                // Opcional: Resetear tiempotranscurrido si quieres que la lluvia pueda ser reactivada
                tiempotranscurrido = 0;
            }
        }
    }
}
