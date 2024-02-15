using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
public class dailygift : MonoBehaviour
{
    public knopka knop;
    byte kun=0,soat=0,minut=0,min1=0,so1=0;
    float sekund=0;
    byte sovgalar=3;
    public GameObject batn,b1;
        // Start is called before the first frame update
    void Start()
    {
        sekund=float.Parse(File.ReadAllText(Application.persistentDataPath + "/missiyason.txt"));
        kun=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/missiyamin.txt"));
        soat=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/missiyasat.txt"));
        minut=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/missiyadaq.txt"));
        sekund=float.Parse(File.ReadAllText(Application.persistentDataPath + "/missiyason.txt"));
    }

    // Update is called once per frame
    void Update()
    {
        DateTime surok=DateTime.Now;
        sekundimer();
        //surok.Day>kun&&(surok.Hour>soat||(surok.Hour==soat&&(surok.Minute>minut||(surok.Minute==minut&&surok.Second>=sekund))))
        if((so1>25)){
                File.WriteAllText(Application.persistentDataPath + "/missiyamin.txt",surok.Day.ToString());
                File.WriteAllText(Application.persistentDataPath + "/missiyasat.txt",surok.Hour.ToString());
                File.WriteAllText(Application.persistentDataPath + "/missiyadaq.txt",surok.Minute.ToString());
                File.WriteAllText(Application.persistentDataPath + "/missiyason.txt",surok.Second.ToString());
                kun=(byte)DateTime.Now.Day;
                soat=(byte)DateTime.Now.Hour;
                minut=(byte)DateTime.Now.Minute;
                batn.SetActive(true);
                b1.SetActive(false);
        }
    }
    void sekundimer(){
        //DateTime avval=new DateTime(DateTime.Now.Year,DateTime.Now.Month,kun+1,soat,minut,(int)sekund);
        sekund+=Time.deltaTime;
        if(DateTime.Now.Day!=kun){
        so1=(byte)(soat-(DateTime.Now.Hour));
        }else{
            so1=(byte)(soat+24-(DateTime.Now.Hour));
        }
        if(minut<=DateTime.Now.Minute){
        min1=(byte)(60-(DateTime.Now.Minute-minut));
        so1--;
        }else{
            min1=(byte)(minut-DateTime.Now.Minute);
        }
        if(minut==DateTime.Now.Minute&&kun==DateTime.Now.Day&&soat==DateTime.Now.Hour&&sekund<DateTime.Now.Second){
            min1=59;
        }else{
            
        }

    }
}
