using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public int[] id;
    public string[] productName;
    public int[] price;
    public int numberOfProducts;
    public GameObject tiendaMenu;

    public GameObject[] products; 
void Start()
{
    
}

public void OpenStore()
{
    tiendaMenu.SetActive(true);

}


    public void CloseStore()
    {
        tiendaMenu.SetActive(false);
    }

    // You can add methods for navigation (e.g., Left, Right) if needed
}
