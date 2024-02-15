using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

public class meyshn : MonoBehaviour
{
    public shar shar;
    public GameObject k1;
    public string manzil="/001.txt",javob="1";
    bool ishladi,topilmadi=true;
    public int pul=500,micq=1000;
    public bool vaqt=true,Daily=true,tash=false,muziqa=false,cheek=false;
    byte kun;
    public byte vaxt=30;
    public TMP_Text dudu;
    public RawImage ri,fon;
    public Texture texture,tex1;
    // Start is called before the first frame update
    void Start()
    {
        if(File.ReadAllText(Application.persistentDataPath + manzil)==javob){
            ishladi=true;
        }
        kun=byte.Parse(File.ReadAllText(Application.persistentDataPath + manzil+"t"));
        topilmadi=false;
        if(kun!=DateTime.Now.Day&&Daily){
            ishladi=false;
            File.WriteAllText(Application.persistentDataPath + manzil,"0");
        }
        taktak();
    }
    void taktak(){
        if(ishladi){
            ri.texture=texture;
            fon.texture=tex1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(kun!=DateTime.Now.Day&&Daily){
            ishladi=false;
            File.WriteAllText(Application.persistentDataPath + manzil,"0");
        }
        if(topilmadi){
            File.WriteAllText(Application.persistentDataPath + manzil,"0");
            File.WriteAllText(Application.persistentDataPath + manzil+"t","0");
        }
        if(vaqt){
        if(shar.oytime>=vaxt*60&&!ishladi){
            k1.SetActive(true);
        }
        }else{
            if(dudu.text=="X3"&&!ishladi&&!tash){
                k1.SetActive(true);
            }
            if(int.Parse(dudu.text)>=micq&&!ishladi&&!tash){
                k1.SetActive(true);
            }
        }

        if(tash){
            if(shar.tash>=micq&&!ishladi){
                k1.SetActive(true);
            }
        }
    }
    public void qosh(){
        if(muziqa){
            byte ccc=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/abba.txt"));
            if(ccc<4){
                ccc++;
                File.WriteAllText(Application.persistentDataPath + "/abba.txt",(ccc).ToString());
            }
        }else{
            shar.pul+=pul;
        }
        shar.tiktek();
        k1.SetActive(false);
        File.WriteAllText(Application.persistentDataPath + manzil,javob);
        File.WriteAllText(Application.persistentDataPath +manzil+"t",DateTime.Now.Day.ToString());
        ishladi=true;
        shar.pulkodlash();
        kun=(byte)DateTime.Now.Day;
        taktak();
    }
}
