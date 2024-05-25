
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Clase arbitaria para manejar el menú
public class Menu : MonoBehaviour
{
    
    //Salir del juego
   public void Salir()
   {
    SceneManager.LoadScene("PantallaInicio");
   }
}
