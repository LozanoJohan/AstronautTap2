using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public Canvas shop;
    public GameObject[] shopObjs;
    public GameObject[] backs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop()
    {
        shop.GetComponent<Animator>().SetTrigger("Died");
        foreach (GameObject shopObj in shopObjs)
        {
            shopObj.SetActive(false);
        }
        
        foreach (GameObject back in backs)
        {
            back.SetActive(true);
        }
        
    }

    public void CloseShop()
    {
        shop.GetComponent<Animator>().SetTrigger("Close");
        foreach (GameObject shopObj in shopObjs)
        {
            shopObj.SetActive(true);
        }
        
        foreach (GameObject back in backs)
        {
            back.SetActive(false);
        }
    }
}
