
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGloow : MonoBehaviour
{
    public List<ParticleSystem> gloowSystems;
    private float tiempotranscurrido = 0;
    private bool isPlaying = false;

    void Start()
    {
        // Obtiene todos los componentes ParticleSystem en los hijos de este objeto
        gloowSystems = new List<ParticleSystem>(GetComponentsInChildren<ParticleSystem>());
        // Detiene todos los sistemas de partículas desde el inicio
        foreach (var system in gloowSystems)
        {
            system.Stop();
        }
    }

    void Update()
    {   
        if (isPlaying)
        {
            tiempotranscurrido += Time.deltaTime;

            if (tiempotranscurrido >= 5f)
            {
                foreach (var system in gloowSystems)
                {
                    system.Stop(); // Detiene cada sistema de partículas
                }
                isPlaying = false;
                tiempotranscurrido = 0;
            }
        }
    }

    public void PlayGloow()
    {   
        foreach (var system in gloowSystems)
        {
            system.Play(); // Inicia cada sistema de partículas
        }
        isPlaying = true;
        tiempotranscurrido = 0;
    }
}
