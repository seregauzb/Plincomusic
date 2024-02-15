using System.Collections;
using System.Collections.Generic ;
using UnityEngine;
using UnityEngine.Purchasing;
using System.IO;

public class stmanager1 : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider extensionProvider;
    // Replace "your_product_id" with the actual product ID
    string productID="sar_coins",productID1="sar2_coins" ,productID2="3000_coins" ,productID3="4000_coins" ,productID4="10000_coins"  ;
    public knopka knop;
    public AudioSource buying;
    float zagrsec=0;
    bool savdo,producta;
    public GameObject zfon,zag;

    void Start()
    {
        buying=knop.buying;
        InitializePurchasing();
    }
    void Update(){
        if(savdo){
            savdo=false;
            if(producta){
                    PurchaseProduct1();
                }else{
                PurchaseProduct();
                }
        }
    }
    private void Add1000Coins()
    {
        knop.pul+= 20000;
        knop.pulkodlash();
        buyingf();
        File.WriteAllText(Application.persistentDataPath + "/sherali.txt","yoshligimiz");
        knop.shopping();
    }
    private void Add2000Coins()
    {
        knop.pul += 50000;
        knop.pulkodlash();
        buyingf();
        File.WriteAllText(Application.persistentDataPath + "/sherali.txt","yoshligimiz");
        knop.shopping();
    }
    public void buyingf(){
        Destroy(Instantiate(buying,transform.position,transform.rotation),5);
        knop.buycomp.SetActive(true);
        knop.buyfield.SetActive(false);
        knop.sanoq1=3;
    }
    public void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add your product ID to the builder
        builder.AddProduct(productID, ProductType.NonConsumable);
        builder.AddProduct(productID1, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        
        storeController = controller;
        extensionProvider = extensions;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Initialization failed: " + error);
    }
    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError("Initialization failed: " + error + ", " + message);
    }
    public void PurchaseProduct1()
    {
        if (storeController != null)
        {
            Product product1 = storeController.products.WithID(productID1);

            if (product1 != null && product1.availableToPurchase)
            {
                storeController.InitiatePurchase(product1);
                
            }
            else
            {
                Debug.Log("Product not available for purchase.");
            }
        }
        else
        {
            Debug.Log("Store controller is not initialized.");
        }
    }
    public void PurchaseProduct()
    {
        if (storeController != null)
        {
            Product product = storeController.products.WithID(productID);

            if (product != null && product.availableToPurchase)
            {
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("Product not available for purchase.");
            }
        }
        else
        {
            Debug.Log("Store controller is not initialized.");
        }
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        zfon.SetActive(false);
            zag.SetActive(false);
        Debug.Log("Purchase successful: " + args.purchasedProduct.definition.id);
        if(productID=="golden_100_purchase"){
            Add1000Coins();
        }
        if(productID=="100_coins"){
            Add2000Coins();
        }
        // Add your logic for handling the successful purchase here

        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        zfon.SetActive(false);
        zag.SetActive(false);
        Debug.Log("Purchase failed: " + failureReason);
        // Add your logic for handling the failed purchase here
    }
    public void BUYN1(){
        savdo=true;
        productID="sar_coins";
        zagrsec=2;
        zfon.SetActive(true);
        zag.SetActive(true);producta=false;
    }
    public void BUYN2(){
        productID="sar2_coins";
        zagrsec=2;
        savdo=true;
        zfon.SetActive(true);
        zag.SetActive(true);
        producta=true;
    }
}