using UnityEngine;
using Unity;
using Contador;
using System.Collections;

namespace WorldTime {
public class TrigoControlSembrado : MonoBehaviour
{
    public GameObject clock; // Referencia al GameObject que tiene el componente Timer.
    public int etapa = 0;
    private float etapaTimer = 0f; // Contador para controlar cuándo cambiar de etapa.

    private bool sembrado;

    private  int cocktador = 0;





    public GameObject light; // Asumo que este es el GameObject que tiene el componente WorldLight.
    public GameObject tile; // Asumo que este es el GameObject que tiene el componente Tile.
    public GameObject draggedTrigo; // Asumo que este es el GameObject que tiene el componente DragTrigo.
    public GameObject PlantingCrop;

    void Start()
    {
        etapa = 0;
        sembrado = false;
        
    }

    void FixedUpdate()
    {
        // Obtener los componentes de los GameObjects.
        Tile tileComponent = tile.GetComponent<Tile>();
        DragTrigo dragTrigoComponent = draggedTrigo.GetComponent<DragTrigo>();
        WorldLight worldLightComponent = light.GetComponent<WorldLight>();


        // Incrementar el contador de etapa.
        etapaTimer += Time.deltaTime;

        // Cambiar la etapa actual cuando 
        if (tileComponent.IsTouched && DragTrigo.isDragging && !sembrado)
        {
            etapa = 1;
            //en esta condicion lo quiero decrementar al contador maiz
            GameObject.FindAnyObjectByType<Contadores>().DecrementarContadorTrigo();
        }
        

        if (etapa==0)//cuando no hay semillas
        {
            sembrado = false;
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
            sembrado = true;

            //Reproduce sonido de sembrado
            sound();
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
    

        if(etapa !=0 && worldLightComponent.running && sembrado){
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

    void sound()
    {
        if (cocktador == 0)
        {
            cocktador++;
            PlantingCrop.GetComponent<AudioSource>().Play();
        }
    }
    

    
    
}
}


