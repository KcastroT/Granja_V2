using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameToDB : MonoBehaviour
{

    struct User
    {
        public string nombre;
        public string apellido;
        public string correo;
        public string contrasena;
        public string anio_nacimiento;
        public string genero;
    }

    struct Game
    {
        public int idUsuario;
        public string financiamiento;
        public int puntaje;
    }

    struct Question
    {
        public int idUsuario;
        public int idPregunta;
        public string contenido;
    }

    struct Answer
    {
        public int pregunta_idpregunta;
        public string contenido;
        public string is_correct;
    }





    public IEnumerator UploadUser(string _nombre, string _apellido, string _correo, string _contrasena, string _anio_nacimiento, string _genero)
{
    User user;
    user.nombre = _nombre;
    user.apellido = _apellido;
    user.correo = _correo;
    user.contrasena = _contrasena;
    user.anio_nacimiento = _anio_nacimiento;
    user.genero = _genero;
    string json = JsonUtility.ToJson(user);

    Debug.Log(json);

    using (UnityWebRequest www = UnityWebRequest.Post("http://44.222.38.209:8080/usuarios", json, "application/json"))
    {
        yield return www.SendWebRequest();
        HandleResponse(www);
    }
}

    public IEnumerator UploadGame(int _idUsuario, string _financiamiento, int _puntaje)
    {
        Game game;
        game.idUsuario = _idUsuario;
        game.financiamiento = _financiamiento;
        game.puntaje = _puntaje;
        string json = JsonUtility.ToJson(game);

        using (UnityWebRequest www = UnityWebRequest.Post("http://44.222.38.209:8080/", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    public IEnumerator UploadQuestion(int _idUsuario, int _idPregunta, string _contenido)
    {
        Question question;
        question.idUsuario = _idUsuario;
        question.idPregunta = _idPregunta;
        question.contenido = _contenido;
        string json = JsonUtility.ToJson(question);

        using (UnityWebRequest www = UnityWebRequest.Post("http://44.222.38.209:8080/", json, "application/json"))
        {
            yield return www.SendWebRequest();
            HandleResponse(www);
        }
    }

    public IEnumerator UploadAnswer(int _pregunta_idpregunta, string _contenido, string _is_correct)
    {
        Answer answer;
        answer.pregunta_idpregunta = _pregunta_idpregunta;
        answer.contenido = _contenido;
        answer.is_correct = _is_correct;
        string json = JsonUtility.ToJson(answer);

        using (UnityWebRequest www = UnityWebRequest.Post("http://44.222.38.209:8080/", json, "application/json"))
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