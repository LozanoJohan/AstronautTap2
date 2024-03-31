using UnityEngine;

public class Shop : MonoBehaviour
{
    public Canvas shop;
    public GameObject[] shopObjs;
    public GameObject[] backs;
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
