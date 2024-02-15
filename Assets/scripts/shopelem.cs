using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class shopelem : MonoBehaviour
{
    public knopka knop;
    public GameObject[] knops;
    public bool qs,bs,cs,ds,es,fs,render;float sanq=4;
    bool qayta=true;
    public AudioSource buying;

    // Start is called before the first frame update
    void Start()
    {
        saralash("ballnum.ToString()","/a.txt",knops[0],0);
        saralash("Int.Parse()","/b.txt",knops[1],1);
        saralash("float.Parse()","/c.txt",knops[2],2);
        saralash("double.Parse()","/d.txt",knops[3],3);
        saralash("byte.Parse()","/e.txt",knops[4],4);
        saralash("short.Parse()","/f.txt",knops[5],5);
        qayta=false;
        knop.shopping();
    }

    // Update is called once per frame
    void Update()
    {
        if(qayta){
            File.WriteAllText(Application.persistentDataPath + "/a.txt","b");
            File.WriteAllText(Application.persistentDataPath + "/b.txt","b");
            File.WriteAllText(Application.persistentDataPath + "/c.txt","b");
            File.WriteAllText(Application.persistentDataPath + "/d.txt","b");
            File.WriteAllText(Application.persistentDataPath + "/e.txt","b");
            File.WriteAllText(Application.persistentDataPath + "/f.txt","b");
            qayta=false;
        }
        if(render){
        if(qs){
            knops[0].GetComponent<RawImage>().enabled=true;
        }
        if(bs){
            knops[1].GetComponent<RawImage>().enabled=true;
        }
        if(cs){
            knops[2].GetComponent<RawImage>().enabled=true;
        }
        if(ds){
            knops[3].GetComponent<RawImage>().enabled=true;
        }
        if(es){
            knops[4].GetComponent<RawImage>().enabled=true;
        }
        if(fs){
            knops[5].GetComponent<RawImage>().enabled=true;
        }
        }
        
        sanq-=Time.deltaTime;
        if(sanq>0){
            sanq=0;
            gameObject.SetActive(false);
        }else{
            render=true;
        }
    }
    void saralash(string ss,string adressa,GameObject go,byte bul){
        if(File.ReadAllText(Application.persistentDataPath + adressa)==ss){
            Debug.Log(bul.ToString());
            switch(bul){
                case 0:qs=true;knop.doublex=true;break;
                case 1:bs=true;knop.faster=true;break;
                case 2:cs=true;knop.square=true;break;
                case 3:ds=true;knop.circle=true;break;
                case 4:es=true;knop.ballnum=1;break;
                case 5:fs=true;knop.ballnum=2;break;
            }
        }
    }
    public void a(){
        if(knop.pul>=15000&&!qs){
            knop.pul-=15000;
            qs=true;
        knop.doublex=true;
        knops[0].GetComponent<RawImage>().enabled=true;
        File.WriteAllText(Application.persistentDataPath + "/a.txt","ballnum.ToString()");
        buyingf();
        }else{
            knop.buyfieldf();
            Debug.Log(qs);
        Debug.Log(bs);
        Debug.Log(cs);
        Debug.Log(ds);
        Debug.Log(es);
        Debug.Log(fs);
        }

    }
    public void b(){
        if(knop.pul>=20000&&!bs){
            knop.pul-=15000;
            bs=true;
        knop.faster=true;
        knops[1].GetComponent<RawImage>().enabled=true;
        File.WriteAllText(Application.persistentDataPath + "/b.txt","Int.Parse()");
        buyingf();
        }else{
            knop.buyfieldf();
        }
    }
    public void c(){
        if(knop.pul>=15000&&!cs){
            knop.pul-=15000;
            cs=true;
        knop.square=true;
        knops[2].GetComponent<RawImage>().enabled=true;
        File.WriteAllText(Application.persistentDataPath + "/c.txt","float.Parse()");
        buyingf();
        }else{
            knop.buyfieldf();
        }
    }
    public void d(){
        if(knop.pul>=15000&&!ds){
            knop.pul-=15000;
            ds=true;
        knop.circle=true;
        knops[3].GetComponent<RawImage>().enabled=true;
        File.WriteAllText(Application.persistentDataPath + "/d.txt","double.Parse()");
        buyingf();
        }else{
            knop.buyfieldf();
        }
    }
    public void e(){
        if(knop.pul>=15000&&!es){
            knop.pul-=15000;
            es=true;
        knop.ballnum=1;
        knop.taxtatalla();
        knops[4].GetComponent<RawImage>().enabled=true;
        File.WriteAllText(Application.persistentDataPath + "/e.txt","byte.Parse()");
        buyingf();
        }
        else{
            knop.buyfieldf();
        }
    }
    public void f(){
        if(knop.pul>=15000&&!fs){
            knop.pul-=15000;
            fs=true;
        knop.ballnum=2;
        knop.taxtatalla();
        knops[5].GetComponent<RawImage>().enabled=true;
        File.WriteAllText(Application.persistentDataPath + "/f.txt","short.Parse()");
        buyingf();
        }else{
            knop.buyfieldf();
        }
    }
    public void g(){
        if(knop.pul>=15000){
            
        knop.pul+=50000;
        buyingf();
        }
    }
    public void h(){
        if(knop.pul>=15000){
        knop.pul+=200000;
        buyingf();
    }}
    public void buyingf(){
        Destroy(Instantiate(buying,transform.position,Quaternion.identity),5);
        knop.buycomp.SetActive(true);
        knop.sanoq1=3;
    }
}
