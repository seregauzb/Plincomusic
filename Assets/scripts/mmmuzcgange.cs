using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class mmmuzcgange : MonoBehaviour
{
    public Texture[] icons;
    public RawImage ri;
    byte mnom=0,chek=0;
    public AudioSource[] ass;
    public AudioSource asu;
    public TMP_Text melt;
    public GameObject k1,k2;
    // Start is called before the first frame update
    void Start()
    {
        mnom=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqola3a.txt"));
        chek=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/abba.txt"));
        asu=Instantiate(ass[mnom]);
    }
    public void rebuild(){
        mnom=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqola3a.txt"));
        chek=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/abba.txt"));
        Destroy(asu);
        asu=Instantiate(ass[mnom]);
    }

    // Update is called once per frame
    void Update()
    {
        melt.text="Melody "+(mnom+1).ToString();
        if(mnom==0){
            k1.SetActive(false);
        }else{
            k1.SetActive(true);
        }
        if(mnom==chek){
            k2.SetActive(false);
        }else{
            k2.SetActive(true);
        }
    }
    public void next(){
        if(mnom<chek){
            mnom++;
            Destroy(asu);
            asu=Instantiate(ass[mnom]);
            yozish();
        }
    }
    public void prev(){
        if(mnom>0){
            mnom--;
            Destroy(asu);
            asu=Instantiate(ass[mnom]);
            yozish();
        }
    }
    void yozish(){
        ri.texture=icons[mnom];
        File.WriteAllText(Application.persistentDataPath + "/maqola3a.txt",mnom.ToString());
    }
}
