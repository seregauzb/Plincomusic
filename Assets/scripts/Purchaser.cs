using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    public knopka knop;
    public AudioSource buying;
    public void OnPurchaseCompleted(Product product)
    {
        switch(product.definition.id)
        {
            case "50_coins":
                Add50000Coins();
                break;
            case "100_coins":
                Add200000Coins();
                break;

        }
    }

    private void Add50000Coins()
    {
        knop.pul+= 50000;
        knop.pulkodlash();
        buyingf();
    }
    private void Add200000Coins()
    {
        knop.pul += 100000;
        knop.pulkodlash();
        buyingf();
    }
    public void buyingf(){
        Destroy(Instantiate(buying,transform.position,transform.rotation),5);
        knop.buycomp.SetActive(true);
        knop.buyfield.SetActive(false);
        knop.sanoq1=3;
    }
}
