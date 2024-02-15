using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System;

public class knopka : MonoBehaviour
{
    public GameObject[] knopkas,missions;
    public byte[] misbul;
    public byte qism=0,kun=0,oykun=0,ballnum=1,kaltaknum,kun1=0,kun2=0;
    public int pul=1000,marta=0;
    short ydelta=1920/2;
    public float tezlik=0,orntvaqt,sanoq1=0;
    bool yozilmagan=true;
    public Material materialkaltak;
    public Color c1,c2,c3,c4,c5;
    public bool doublex=false,faster=false,square=false,circle=false;
    public GameObject circlescheme,sqsch,buyfield,buycomp, splash;
    public PhysicMaterial material;
    string mis1,mis2,mis3,mis4,mis5,mis6;
    Touch touch;
    public TMP_Text pultmp,schtext,settext;
    public AudioSource buying;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(splash,3);
        material.bounciness=1f;
        saralash();
        oqish();
        taxtatalla();
        
        vaqt();
        if(File.ReadAllText(Application.persistentDataPath + "/aa.txt")=="Ona yurting oltin beshiging"){
            Physics.gravity=new Vector3(0,-400,0);
        }else{
            Physics.gravity=new Vector3(0,-500,0);
        }
        pultmp.text=pul.ToString();
        settext.text=pul.ToString();
    }
    void martaf(){
        marta++;
        File.WriteAllText(Application.persistentDataPath + "/marta.txt",marta.ToString());
    }
    public void pp(){
        Application.OpenURL("https://docs.google.com/document/d/15wXCn0IJ1qOGdreA7s6uMsO5kaS0lrsam1AodlVVJGg/edit?usp=sharing");
    }
    public void pp1(){
        Application.OpenURL("https://docs.google.com/document/d/1MvAqEVF626uxfdAjqHp4kM9K2aucSdQvdv4vlwDy8v8/edit?usp=sharing");
    }
    public void pp2(){
        Application.OpenURL("https://docs.google.com/document/d/1sk9b2R_sr-FCCyUHNg48KsChyuw_wC4uR6bHmlYvooc/edit?usp=sharing");
    }
    // Update is called once per frame
    void Update()
    {
        if(sanoq1>0){
        sanoq1-=Time.deltaTime;
        if(sanoq1<=0){
            buycomp.SetActive(false);
            buyfield.SetActive(false);
        }
        }
        if(yozilmagan){
            yozish();
        }
        orntvaqt+=Time.deltaTime;
        kun+=timerkun();
        oykun+=timerkun();
        saralash();


        /*if(kun>6){
            kun=0;
            misya(0);
        }
        if(pul>=200000&&File.ReadAllText(Application.persistentDataPath + "/ozod.txt")=="lola"){
            File.WriteAllText(Application.persistentDataPath + "/ozod.txt","binafsha");
            misya(2);
        }else{
            if(File.ReadAllText(Application.persistentDataPath + "/ozod.txt")=="binafsha"){
                misyan(2);
            }
        }
        if(oykun>=6){
            misya(1);
        }
        if(mis1=="kantare"){
            misya(3);
            File.WriteAllText(Application.persistentDataPath + "/gulom.txt","naydabor");
        }else{
            if(File.ReadAllText(Application.persistentDataPath + "/gulom.txt")=="naydabor"){
                misyan(3);
            }
        }
        if(mis2=="ketmagin gulim"){
            misya(4);
            File.WriteAllText(Application.persistentDataPath + "/ozodbek.txt","kutaman");
        }else{
            if(File.ReadAllText(Application.persistentDataPath + "/ozodbek.txt")=="kutaman"){
                misyan(4);
            }
        }
        if(mis3=="onam"){
            misya(5);
            File.WriteAllText(Application.persistentDataPath + "/botir.txt","go'zalsan");
        }else{
            if(File.ReadAllText(Application.persistentDataPath +  "/botir.txt")=="go'zalsan"){
                misyan(5);
            }
        }
        if(mis4=="qizg'aldoq"){
            misya(6);
            File.WriteAllText(Application.persistentDataPath + "/aslbek.txt","lezginka");
        }else{
            if(File.ReadAllText(Application.persistentDataPath +"/aslbek.txt")=="lezginka"){
                misyan(6);
            }
        }
        if(mis5=="18da edim o'shanda"){
            misya(7);
            File.WriteAllText(Application.persistentDataPath + "/sherali.txt","yoshligimiz");
        }else{
            if(File.ReadAllText(Application.persistentDataPath +"/sherali.txt")=="yoshligimiz"){
                misyan(7);
            }
        }
        if(mis6=="O'zbekiston"){
            misya(8);
            File.WriteAllText(Application.persistentDataPath + "/yulduz.txt","qizg'aldog'im");
        }else{
            if(File.ReadAllText(Application.persistentDataPath + "/yulduz.txt")=="qizg'aldog'im"){
                misyan(8);
            }
        }*/
        ydelta+=(short)tezlik;
        transform.position=new Vector3 (transform.position.x,ydelta,0);
    }
    public void taxtatalla(){
        switch(kaltaknum){
            case 0:materialkaltak.SetColor("_EmissionColor", c1);materialkaltak.SetColor("_Color", c1);break;
            case 1:materialkaltak.SetColor("_EmissionColor", c2);materialkaltak.SetColor("_Color", c2);break;
            case 2:materialkaltak.SetColor("_EmissionColor", c3);materialkaltak.SetColor("_Color", c3);break;
            case 3:materialkaltak.SetColor("_EmissionColor", c4);materialkaltak.SetColor("_Color", c4);break;
            case 4:materialkaltak.SetColor("_EmissionColor", c5);materialkaltak.SetColor("_Color", c5);break;
        }
    }
    byte timerkun(){
        byte qu=0;
        while(orntvaqt>3600*24){
            orntvaqt-=3600*24;
            qu++;
        }
        return qu;
    }
    public void saralash(){
        pul=pulochish((File.ReadAllText(Application.persistentDataPath + "/hayvonlar.txt")));
        schtext.text=pul.ToString();
        settext.text=pul.ToString();
        /*int i=0;
        while(i<knopkas.Length){
            if(i==qism){
                knopkas[i].SetActive(true);
                i++;
            }else{
            knopkas[i].SetActive(false);
            i++;
            }
        }*/
    }
    void bbbb(){
        if(tezlik>0){
            tezlik-=Time.deltaTime*10;
        }
        if(tezlik<0){
            tezlik+=Time.deltaTime*10;
        }
    }
    public void a(){
        qism=0;   
    }
    public void b(){
        qism=1;   
    }
    public void c(){
        qism=2;   
    }
    public void d(){
        File.WriteAllText(Application.persistentDataPath + "/qozi.txt","0");  
    }
    public void e(){
        File.WriteAllText(Application.persistentDataPath + "/qozi.txt","1");  
    }
    public void f(){
        File.WriteAllText(Application.persistentDataPath + "/qozi.txt","2");    
    }
    public void g(){
        qism=6;   
    }
    public void ple(){
        samus();
        samus1();
        pulkodlash();
        //File.WriteAllText(Application.persistentDataPath + "/maqol3.txt",ballnum.ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + qism+1);
    }
    void misya(byte cx){
        if(misbul[cx]==0){
                misbul[cx]=1;
            switch(cx){
                case 0:pul+=1000;break;
                case 1:pul+=1000;break;
                case 2:pul+=10000;break;
                case 3:pul+=15000;break;
                case 4:pul+=1000;break;
                case 5:pul+=5000;break;
                case 6:pul+=1000;break;
                case 7:pul+=1000;break;
                case 8:pul+=10000;break;
            }
        }
        misrasta();
    }
    void misyan(byte cx){
        if(misbul[cx]==0){
                misbul[cx]=1;
        }
        misrasta();
    }
    void misrasta(){
        byte aaaaaaaa=0;
        while(aaaaaaaa<misbul.Length){
            if(misbul[aaaaaaaa]==1){
                missions[aaaaaaaa].SetActive(false);
            }
            aaaaaaaa++;
        }
        pulkodlash();
    }
    void yozish(){
        File.WriteAllText(Application.persistentDataPath + "/maqollar1.txt","Ona bilan bola gul bilan lola");
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt1.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/maqollar.txt","Ona bilan bola gul bilan lola");
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/maqol3.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/ozod.txt","lola");
        File.WriteAllText(Application.persistentDataPath + "/gulom.txt","dilorom");
        File.WriteAllText(Application.persistentDataPath + "/ozodbek.txt","may");
        File.WriteAllText(Application.persistentDataPath + "/botir.txt","adashdim");
        File.WriteAllText(Application.persistentDataPath + "/aslbek.txt","boylama");
        File.WriteAllText(Application.persistentDataPath + "/sherali.txt","oshiq bo'ldim");
        File.WriteAllText(Application.persistentDataPath + "/yulduz.txt","alam");
        kun1=(byte)DateTime.Now.Day;
        File.WriteAllText(Application.persistentDataPath + "/marta1.txt",kun1.ToString());
        File.WriteAllText(Application.persistentDataPath + "/marta.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/missiya1.txt","a");
        File.WriteAllText(Application.persistentDataPath + "/missiya2.txt","b");
        File.WriteAllText(Application.persistentDataPath + "/missiya3.txt","c");
        File.WriteAllText(Application.persistentDataPath + "/missiya4.txt","d");
        File.WriteAllText(Application.persistentDataPath + "/missiya5.txt","e");
        File.WriteAllText(Application.persistentDataPath + "/missiya6.txt","f");
        DateTime surok=DateTime.Now;
        File.WriteAllText(Application.persistentDataPath + "/missiyamin.txt",surok.Day.ToString());
        File.WriteAllText(Application.persistentDataPath + "/missiyasat.txt",surok.Hour.ToString());
        File.WriteAllText(Application.persistentDataPath + "/missiyadaq.txt",surok.Minute.ToString());
        File.WriteAllText(Application.persistentDataPath + "/rani.txt","2");
        File.WriteAllText(Application.persistentDataPath + "/maqola3.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/maqola3a.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/maqol3a.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/muziqa.txt","1");
        File.WriteAllText(Application.persistentDataPath + "/muziqa1.txt","1");
        File.WriteAllText(Application.persistentDataPath + "/aa.txt","Ona yurting oltin beshiging");
        File.WriteAllText(Application.persistentDataPath + "/abba.txt","1");
        //File.WriteAllText(Application.persistentDataPath + "/maqola3a.txt","0");




        pul=5000;
        yozilmagan=false;
        pulkodlash();
    }
    void vaqt(){
        kun2=(byte)DateTime.Now.Day;
        if(kun2-kun1>=1&&kun2-kun1<2){
            kun+=1;
        }else{
            if(kun2-kun1>=2){
                kun=0;
            }
        }
    }
    void oqish(){
        kun=sammy(File.ReadAllText(Application.persistentDataPath + "/maqollar1.txt"));
        orntvaqt=float.Parse(File.ReadAllText(Application.persistentDataPath + "/oyvaqt1.txt"));
        oykun=sammy((File.ReadAllText(Application.persistentDataPath + "/maqollar.txt")));
        pul=pulochish(File.ReadAllText(Application.persistentDataPath + "/hayvonlar.txt"));
        ballnum=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3.txt"));
        kaltaknum=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqola3.txt"));
        yozmaaaa();
        marta=int.Parse(File.ReadAllText(Application.persistentDataPath + "/marta.txt"));
        kun1=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/marta1.txt"));
        vaqt();

        yozilmagan=false;
    }
    void yozmaaaa(){
        mis1=(File.ReadAllText(Application.persistentDataPath + "/gulom.txt"));
        mis2=(File.ReadAllText(Application.persistentDataPath + "/ozodbek.txt"));
        mis3=(File.ReadAllText(Application.persistentDataPath + "/botir.txt"));
        mis4=(File.ReadAllText(Application.persistentDataPath + "/aslbek.txt"));
        mis5=(File.ReadAllText(Application.persistentDataPath + "/sherali.txt"));
        mis6=(File.ReadAllText(Application.persistentDataPath + "/yulduz.txt"));
    }
    void samus(){
        string maqol="";
        switch(kun){
            case 0:maqol="Ona bilan bola gul bilan lola";break;
            case 1:maqol="Mehr ko'zda";break;
            case 2:maqol="Oshing halol bo'lsa ko'chada ye";break;
            case 3:maqol="Ari zaxrin chekmagan bol qadrini bilmas";break;
            case 4:maqol="Axtargan topar";break;
            case 5:maqol="Ahdi borning baxti bor";break;
            case 6:maqol="Bog' jamoli bog'bondan";break;            
        }
        File.WriteAllText(Application.persistentDataPath + "/maqollar1.txt",maqol);
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt1.txt",orntvaqt.ToString());
    }
    void samus1(){
        string maqol="";
        switch(oykun){
            case 0:maqol="Ona bilan bola gul bilan lola";break;
            case 1:maqol="Mehr ko'zda";break;
            case 2:maqol="Oshing halol bo'lsa ko'chada ye";break;
            case 3:maqol="Ari zaxrin chekmagan bol qadrini bilmas";break;
            case 4:maqol="Axtargan topar";break;
            case 5:maqol="Ahdi borning baxti bor";break;
            case 6:maqol="Bog' jamoli bog'bondan";break;            
        }
        File.WriteAllText(Application.persistentDataPath + "/maqollar.txt",maqol);
    }
    byte sammy(string satr){
        byte qqq=0;
        if(satr=="Ona bilan bola gul bilan lola"){
            qqq= 0;
        }
        if(satr=="Mehr ko'zda"){
            qqq= 1;
        }
        if(satr=="Oshing halol bo'lsa ko'chada ye"){
            qqq= 2;
        }
        if(satr=="Ari zaxrin chekmagan bol qadrini bilmas"){
            qqq= 3;
        }
        if(satr=="Axtargan topar"){
            qqq= 4;
        }
        if(satr=="Ahdi borning baxti bor"){
            qqq=5;
        }
        if(satr=="Bog' jamoli bog'bondan"){
            qqq= 6;
        }
        return qqq;
    }

    public void pulkodlash(){
        string soz="";string son=pul.ToString();
        char[] ch1=son.ToCharArray();
        foreach(var v in ch1){
            
            switch(int.Parse(v.ToString())){
                case 0:soz+="ciklop";break;
                case 1:soz+="tiger";break;
                case 2:soz+="elephand";break;
                case 3:soz+="duck";break;
                case 4:soz+="sheep";break;
                case 5:soz+="wolf";break;
                case 6:soz+="hyena";break;
                case 7:soz+="coyote";break;
                case 8:soz+="zebra";break;
                case 9:soz+="buffalo";break;
            }
            soz+="|";
        }
        File.WriteAllText(Application.persistentDataPath + "/hayvonlar.txt",soz);
    }
    int pulochish(string s){
        char[] ch1=s.ToCharArray();
        string[] tillar=new string[9];
        byte dt=0,sanoq=0;
        string soz="";
        string javob="";
        foreach(var a in ch1){
            if(a.ToString()!="|"){
            soz+=a.ToString();dt++;
            }else{
                dt=0;tillar[sanoq]=soz;sanoq++;soz="";
            }
        }
        while(sanoq>0){
            sanoq--;
            s=tillar[sanoq];
        if(s=="ciklop"){
            javob+="0";
        }
        if(s=="tiger"){
            javob+="1";
        }
        if(s=="elephand"){
            javob+="2";
        }
        if(s=="duck"){
            javob+="3";
        }
        if(s=="sheep"){
            javob+="4";
        }
        if(s=="wolf"){
            javob+="5";
        }
        if(s=="hyena"){
            javob+="6";
        }
        if(s=="coyote"){
            javob+="7";
        }
        if(s=="zebra"){
            javob+="8";
        }
        if(s=="buffalo"){
            javob+="9";
        }
        Debug.Log(javob);
        }
        soz="";
        ch1=javob.ToCharArray();
        Debug.Log(javob);
        foreach(var a in ch1){
            soz=a.ToString()+soz;
        }
        return int.Parse(soz);
    }
    public void shopping(){
        if(square){
            sqsch.SetActive(true);
        }
        if(circle){
            circlescheme.SetActive(true);
        }
        if(circle&&square){
            File.WriteAllText(Application.persistentDataPath + "/aslbek.txt","qizg'aldoq");
        }
        if(faster){
            Physics.gravity=new Vector3(0,-500,0);
            File.WriteAllText(Application.persistentDataPath + "/aa.txt","Ona yurting oltin beshiging");
        }else{
            Physics.gravity=new Vector3(0,-500,0);
            File.WriteAllText(Application.persistentDataPath + "/aa.txt","Ona yurting omon bo'lsa rangu ro'ying somon bo'lmas");
        }
        if(marta>=100&&mis1=="dilorom"){
            marta=0;
            File.WriteAllText(Application.persistentDataPath + "/gulom.txt","kantare");
        }
        taxtatalla();
        yozmaaaa();
        pultmp.text=pul.ToString();
    }
    public void buyfieldf(){
        sanoq1=3;
        buyfield.SetActive(true);
        buycomp.SetActive(false);
    }
}
