using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    public static UIInfo Instance;

    [SerializeField]
    GameObject removeAdsBtn;
    [SerializeField]
    Text coinsText;

    void Start()
    {
        Instance = this;
        UpdateRemoveAdsButton();
        UpdateCoinsText();
    }

    public void UpdateRemoveAdsButton()
    {
        bool removeAds = PlayerPrefs.GetInt("removeads") == 1;
        removeAdsBtn.SetActive(!removeAds);
    }

    public void UpdateCoinsText()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = "Coins " + coins;
    }

}
