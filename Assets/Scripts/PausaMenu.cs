using UnityEngine;
using TMPro;

public class PausaMenu : MonoBehaviour
{
    public GameObject pausaPanel;

   public void Pause()
   {
    pausaPanel.SetActive(true);
    Time.timeScale = 0;
    
   }

   public void Continue(){
    pausaPanel.SetActive(false);
    Time.timeScale = 1;
   }
}
