using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class lenta : MonoBehaviour
{
    bool go=true,lol;
    Vector3 bosh;
    public float min,max,tezlik=1;
    Ray ray;
    int pul;
    RaycastHit hit;
    public Camera kemera;
    public GameObject menyu;
    public Transform yutp;
    public GameObject[] yutuqlar;
    GameObject yutuq;
    // Start is called before the first frame update
    void Start()
    {
        bosh=transform.position;
        pul=pulochish(File.ReadAllText(Application.persistentDataPath + "/hayvonlar.txt"));
    }

    // Update is called once per frame
    void Update()
    {
        if(lol){
            if(transform.position.x<min+640){
                Debug.Log("dsd");
                transform.position=new Vector3(max,transform.position.y,transform.position.z);
            }
        if(go){
            tezlik=10000;
        }else{
            tezlik-=1000*Time.deltaTime;
            if(tezlik<=10){
                tezlik=1000;
                lol=false;
                ray=new Ray(kemera.transform.position, this.kemera.transform.forward);
                Debug.DrawRay(this.kemera.transform.position, this.kemera.transform.forward * 500f, Color.yellow);
                if (Physics.Raycast(ray, out hit)){
                    menyu.SetActive(true);
                    pul+=int.Parse(hit.collider.tag);
                    switch(hit.collider.tag){
                        case "100":yutuq=Instantiate(yutuqlar[0],yutp.position,transform.rotation);break;
                        case "200":yutuq=Instantiate(yutuqlar[1],yutp.position,transform.rotation);break;
                        case "500":yutuq=Instantiate(yutuqlar[2],yutp.position,transform.rotation);break;
                    }
                    pulkodlash();
                    yutuq.transform.parent=menyu.transform;
                    yutuq.transform.localScale=new Vector3(.4f,.6f,1);
                    

                }
            }
        }
        transform.Translate(-tezlik*Time.deltaTime,0,0);
        }
    }
    public void gof(){
        go=true;
        lol=true;
    }
    public void goxf(){
        go=false;
    }
    public void sssr(){
        Destroy(yutuq);
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
    
}
