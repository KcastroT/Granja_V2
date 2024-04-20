using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameToDB : MonoBehaviour
{

    IEnumerator UploadUser(string _nombre, string _apellido, string _correo, string _contrasena, string _anio_nacimiento, string _genero)
    {
        string json = JsonUtility.ToJson(new
        {
            nombre = _nombre,
            apellido = _apellido,
            correo = _correo,
            contrasena = _contrasena,
            anio_nacimiento = _anio_nacimiento,
            genero = _genero
        });

        using (UnityWebRequest www = UnityWebRequest.Post("URL", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    IEnumerator UploadGame(int _idUsuario, string _financiamiento, int _puntaje)
    {
        string json = JsonUtility.ToJson(new
        {
            idUsuario = _idUsuario,
            financiamiento = _financiamiento,
            puntaje = _puntaje
        });

        using (UnityWebRequest www = UnityWebRequest.Post("URL", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    IEnumerator UploadQuestion(int _idUsuario, int _idPregunta, string _contenido)
    {
        string json = JsonUtility.ToJson(new
        {
            idUsuario = _idUsuario,
            idPregunta = _idPregunta,
            contenido = _contenido
        });

        using (UnityWebRequest www = UnityWebRequest.Post("URL", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    IEnumerator UploadAnswer(int _pregunta_idpregunta, string _contenido, string _is_correct)
    {
        string json = JsonUtility.ToJson(new
        {
            pregunta_idpregunta = _pregunta_idpregunta,
            contenido = _contenido,
            is_correct = _is_correct
        });

        using (UnityWebRequest www = UnityWebRequest.Post("URL", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    void HandleResponse(UnityWebRequest www)
    {
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}