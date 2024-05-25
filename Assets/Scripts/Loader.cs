
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Clase arbirtraria para manejar la carga de escenas
public class Loader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;

    // Función para iniciar la carga de la escena
    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    // Corutina para cargar la escena de manera asíncrona
    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            yield return null;
        }
    }
}
