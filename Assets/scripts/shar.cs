using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class shar : MonoBehaviour
{
    public Vector3 bosh;
    public bool tur=true,otildi=false,autoplay=false,tashlandi=false,birinch=false;
    public int pul,tikilganpul,first;
    public float foizi=1,oytime=0,ortime=0,sanoq=0;
    public TMP_Text tikpultext,foiztext,pultext,bwtext,bwres,bigvinarm;
    public byte kun=0,ornkul,bolnum=0,koef=1,tash=0;
    string kunso;
    PhysicMaterial pm;
    public Texture[] ballssss,fields;
    public RawImage image,fayld,maska;
    public GameObject win,urok,yutdingiz,yutqazdiz;
    public AudioSource sound,yutti,yutqazdi,muziqa;
    public AudioSource[] ass;
    // Start is called before the first frame update
    void Start()
    {
        bolnum=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3.txt"));
        image.texture=ballssss[bolnum];
        maska.texture=fields[byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3a.txt"))];
        fayld.texture=fields[byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3a.txt"))];
        gameObject.GetComponent<SphereCollider>().material.bounciness=1f;
        bosh=new Vector3(transform.position.x,transform.position.y,transform.position.z);
        tashla();
        pultikishp();
        kunso=File.ReadAllText(Application.persistentDataPath + "/maqollar.txt");
        kun=sammy(kunso);
        kunso=File.ReadAllText(Application.persistentDataPath + "/maqollar1.txt");
        ornkul=sammy(kunso);
        oytime=float.Parse(File.ReadAllText(Application.persistentDataPath + "/oyvaqt.txt"));
        ortime=float.Parse(File.ReadAllText(Application.persistentDataPath + "/oyvaqt1.txt"));
        pul=pulochish(File.ReadAllText(Application.persistentDataPath + "/hayvonlar.txt"));
        pultext.text=pul.ToString();
        //saralash("ballnum.ToString()","/a.txt",0);
        //saralash("Int.Parse()","/b.txt",1);
        /*if(File.ReadAllText(Application.persistentDataPath + "/rani.txt")=="2"){
            File.WriteAllText(Application.persistentDataPath + "/rani.txt","8");
            urok.SetActive(true);
        }*/
        muziqa=Instantiate(ass[byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqola3a.txt"))]);
        muziqa.volume=.7f;
        first=pul;
        muzyoq();
        ovozyoq();
        tash=0;
    }

    // Update is called once per frame
    void Update()
    {
        oytime+=Time.deltaTime;
        ortime+=Time.deltaTime;
        kun+=timerkun();
        ornkul+=timeroykun();
        if(tur){
            transform.position=bosh;
            if(autoplay){
                tur=false;
                tashla();
                pulol();
            }
        }
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.GetComponent<savat>()==null){
        Destroy(Instantiate(sound,transform.position,transform.rotation),5);
        }
    }
    void saralash(string ss,string adressa,byte bul){
        if(File.ReadAllText(Application.persistentDataPath + adressa)==ss){
            switch(bul){
                case 0:koef=2;break;
                case 1:gameObject.GetComponent<SphereCollider>().material.bounciness=1f;break;
            }
        }
    }
    
    public void apl(){
        autoplay=true;
    }
    public void setimage(){
        
        image.texture=ballssss[bolnum];
    }
    public void setfayld(){
        fayld.texture=fields[byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3a.txt"))];
        maska.texture=fields[byte.Parse(File.ReadAllText(Application.persistentDataPath + "/maqol3a.txt"))];
    }
    public void tashla(){
        if(tikilganpul>=100&&tashlandi==false){
            int a=0;
            if(birinch){
                a=Random.Range(-40,41);
            }else{
                a=Random.Range(-200,201);
            }
        if(a==0){
            a=-1;
        }
        transform.position=bosh;
        transform.position+=new Vector3(a,0,0);
        transform.GetComponent<Rigidbody>().velocity=Vector3.zero;
        otildi=false;
        tash++;
        }
    }
    public void turrma(){
        if(tikilganpul>=100){
        tur=false;
        }
    }
    public void pultikishp(){
        if(tikilganpul<=pul-100){
        tikilganpul+=100;
        tikpultext.text=tikilganpul.ToString();
        }
    }
    public void pultikishm(){
        if(tikilganpul>0){
        tikilganpul-=100;
        tikpultext.text=tikilganpul.ToString();
        }
    }
    public void pultikishpi(){
        if(tikilganpul*2<=pul){
        tikilganpul*=2;
        tikpultext.text=tikilganpul.ToString();
        }
    }
    public void pultikishmi(){
        if(tikilganpul>100){
        tikilganpul/=2;
        tikpultext.text=tikilganpul.ToString();
        }
    }
    public void pulol(){
        if(tashlandi==false){
        pul-=tikilganpul;
        pultext.text=pul.ToString();
        foizi=tikilganpul;
        if(tikilganpul>=5000){
            File.WriteAllText(Application.persistentDataPath + "/ozodbek.txt","kutaman");
        }
        if(pul==0){
            File.WriteAllText(Application.persistentDataPath + "/yulduz.txt","O'zbekiston");
        }
        tashlandi=true;
        }
    }
    public void shopping(){

    }
    public void buyfieldf(){
        //sanoq1=3;
        //buyfield.SetActive(true);
        //buycomp.SetActive(false);
    }
    public void tiktek(){
        while(tikilganpul>pul){
            tikilganpul-=100;
        }
        tikpultext.text=tikilganpul.ToString();
        pultext.text=pul.ToString(); 
        if(pul-first>=15000){
            if(File.ReadAllText(Application.persistentDataPath + "/botir.txt")=="adashdim"){
            File.WriteAllText(Application.persistentDataPath + "/botir.txt","onam");
            }
        }
    }
    public void bigvin(){
        win.SetActive(true);
        bwtext.text="X"+foizi.ToString();
    }
    public void tomainmenu(){
        samus();
        samus1();
        pulkodlash();
        SceneManager.LoadScene("Bosh menu");
    }
    byte timerkun(){
        byte qu=0;
        while(ortime>3600*24){
            ortime-=3600*24;
            qu++;
        }
        return qu;
    }
    byte timeroykun(){
        byte qu=0;
        while(oytime>3600*24){
            oytime-=3600*24;
            qu++;
        }
        return qu;
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
        File.WriteAllText(Application.persistentDataPath + "/maqollar.txt",maqol);
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt.txt","0");
        File.WriteAllText(Application.persistentDataPath + "/oyvaqt1.txt",ortime.ToString());
    }
    void samus1(){
        string maqol="";
        switch(ornkul){
            case 0:maqol="Ona bilan bola gul bilan lola";break;
            case 1:maqol="Mehr ko'zda";break;
            case 2:maqol="Oshing halol bo'lsa ko'chada ye";break;
            case 3:maqol="Ari zaxrin chekmagan bol qadrini bilmas";break;
            case 4:maqol="Axtargan topar";break;
            case 5:maqol="Ahdi borning baxti bor";break;
            case 6:maqol="Bog' jamoli bog'bondan";break;            
        }
        File.WriteAllText(Application.persistentDataPath + "/maqollar1.txt",maqol);
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
    public void ovozyoq(){
        sound.volume=float.Parse(File.ReadAllText(Application.persistentDataPath + "/muziqa.txt"));
        yutti.volume=float.Parse(File.ReadAllText(Application.persistentDataPath + "/muziqa.txt"));
        yutqazdi.volume=float.Parse(File.ReadAllText(Application.persistentDataPath + "/muziqa.txt"));

    }public void ovozoch(){
        sound.volume=1;
        yutti.volume=1;
        yutqazdi.volume=1;
    }public void muzyoq(){
        muziqa.volume=float.Parse(File.ReadAllText(Application.persistentDataPath + "/muziqa1.txt"));
    }public void muzoch(){
        muziqa.volume=.7f;
    }

}
