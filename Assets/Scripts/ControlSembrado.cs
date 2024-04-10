using UnityEngine;
using Unity;
using System.Collections;

namespace WorldTime {
public class ControlSembrado : MonoBehaviour
{
    public GameObject clock; // Referencia al GameObject que tiene el componente Timer.
    public int etapa = 0;
    private float etapaTimer = 0f; // Contador para controlar cuándo cambiar de etapa.

    private bool sembrado;


    public GameObject light; // Asumo que este es el GameObject que tiene el componente WorldLight.
    public GameObject tile; // Asumo que este es el GameObject que tiene el componente Tile.
    public GameObject draggedMaiz; // Asumo que este es el GameObject que tiene el componente DragMaiz.

    void Start()
    {
        etapa = 0;
        sembrado = false;
        
    }

    void FixedUpdate()
    {
        // Obtener los componentes de los GameObjects.
        Tile tileComponent = tile.GetComponent<Tile>();
        DragMaiz dragMaizComponent = draggedMaiz.GetComponent<DragMaiz>();
        WorldLight worldLightComponent = light.GetComponent<WorldLight>();


        // Incrementar el contador de etapa.
        etapaTimer += Time.deltaTime;

        // Cambiar la etapa actual cuando 
        if (tileComponent.IsTouched && DragMaiz.isDragging)
        {
            etapa = 1;
        }
        

        if (etapa==0)//cuando no hay semillas
        {
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
            
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else
                {

                    child.gameObject.SetActive(false);
                }
            }
        }
        else if (etapa==1){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("a"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==2){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("b"))
                {   
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);

                }else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==3){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("c"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==4){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("d"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
        }
        else if (etapa==5){
            // Itera sobre todos los hijos de este GameObject.
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                // Verifica si el nombre del hijo contiene la letra "a".
                if (child.name == "lit")
                {
                        continue; // Salta a la siguiente iteración del bucle, ignorando el hijo "lit".
                }
                else if (!child.name.Contains("e"))
                {
                    // Si el nombre no contiene "a", desactiva el hijo.
                    child.gameObject.SetActive(false);
                }
                else
                {
                    // Si el nombre contiene "a", asegura que el hijo esté activo.
                    child.gameObject.SetActive(true);
                }
            }
    }
    

        if(etapa !=0 && worldLightComponent.running && !sembrado){
            sembrado = true; // Asegura que esta lógica se ejecute una sola vez.
            StartCoroutine(CambiarEtapaConRetraso());
        }
    }
    IEnumerator CambiarEtapaConRetraso()
    {
        for (int i = 1; i <= 5; i++)
        {   
            etapa = i;
            Debug.Log("etapa: "+i);
            // Espera un segundo antes de continuar con el próximo número.
            yield return new WaitForSeconds(0.6f);
        }
    }
    
    
}
}


