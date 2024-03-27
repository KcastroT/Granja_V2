using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int[] id;
    public string[] productName;
    public int[] price;
    public GameObject shopWindow;
    public GameObject[] products;

    void Start()
    {
        for (int i = 0; i < products.Length; ++i)
        {
            products[i].SetActive(false);
        }
    }

    public void OpenStore()
    {
        shopWindow.SetActive(true);

        for (int i = 0; i < products.Length; ++i)
        {
            products[i].SetActive(true);
        }
    }

    public void CloseStore()
    {
        shopWindow.SetActive(false);
    }
}
