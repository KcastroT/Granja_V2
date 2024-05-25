
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para manejar las partículas de la sequía
public class particledesert : MonoBehaviour
{
    public GameObject arbusto;
    public float tiempo = 7f;
    public bool arbustosactiva = false;

    public void sequia()
    {
        arbustosactiva = true;
    }

    void Start()
    {
        arbusto.SetActive(false);
        
    }


    void Update()
    {
        if (arbustosactiva)
        {   
            arbusto.SetActive(true);
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                arbusto.SetActive(false);
                arbustosactiva = false;
                tiempo = 7f;
            }
        }
    }
}
