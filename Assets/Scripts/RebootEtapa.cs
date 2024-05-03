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
using Unity.VisualScripting;
using UnityEngine;

public class RebootEtapa : MonoBehaviour
{
    public bool reboot = false;

    public void IniciaReinicio(){
        StartCoroutine(Reiniciar());
    }
    IEnumerator Reiniciar(){
        reboot = true;
        yield return new WaitForSeconds(0.5f);
        reboot = false;
    }

}
