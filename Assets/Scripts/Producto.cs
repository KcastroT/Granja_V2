using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Producto : MonoBehaviour
{
    public GameObject tiendaMenu;
    public int id;
    public string productName;
    public int price;
    public Text nameText, priceText;

    // Start is called before the first frame update
    void Start()
    {
        tiendaMenu = GameObject.Find("tiendaMenu");
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = "" + productName;
        priceText.text = price + " $";

        
    }
}
