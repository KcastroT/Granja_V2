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

// Clase para manejar los datos del usuario
public class UserDataManager : MonoBehaviour
{
    public static UserDataManager Instance; 

    public string NombreUsuario;
    public string ApellidoUsuario;
    public string AñoNacimientoUsuario;
    public string EmailUsuario;
    public string GeneroUsuario;
    public string IDUsuario; // Asegúrate de obtener y asignar este valor correctamente según tu lógica

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hace que este objeto no se destruya al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruye cualquier duplicado que se cree en nuevas escenas
        }
    }
}
