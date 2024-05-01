using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particledesert : MonoBehaviour
{
    public GameObject arbusto;
    public float tiempo = 7f;
    public bool arbustosactiva = false;

    public void sequia()
    {
        arbustosactiva = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        arbusto.SetActive(false);
        
    }

    // Update is called once per frame
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
