using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class savat : MonoBehaviour
{
    public float pul=1f;
    public GameObject rasm;
    float p1=1;
    // Start is called before the first frame update
    void Start()
    {
        if(pul==0){
            if(rasm.GetComponent<RawImage>()!=null){
                rasm.GetComponent<RawImage>().color=new Color(0,0,0,0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){
        if(other.collider.tag=="Player"){
            shar shar=other.gameObject.GetComponent<shar>();
            if(shar.otildi==false){
                if(pul>1){
                    Destroy(Instantiate(shar.yutti,transform.position,transform.rotation),5);
                }else{
                    Destroy(Instantiate(shar.yutqazdi,transform.position,transform.rotation),5);
                }
            p1=(float)(shar.tikilganpul);
            shar.pul+=(int)(p1*pul*shar.koef);
            shar.tur=true;
            shar.foizi=pul;
            shar.bwres.text="+"+(p1*pul*shar.koef).ToString();
            rasm.SetActive(false);
            rasm.SetActive(true);
            other.transform.position=shar.bosh;
            shar.tiktek();
            shar.otildi=true;
            shar.tashlandi=false;
            if(pul>1){
                shar.foiztext.color=Color.green;
                //shar.foiztext.text="+"+shar.foizi.ToString();
            }else{
                shar.foiztext.color=Color.red;
                //shar.foiztext.text="-"+shar.foizi.ToString();
            }
            other.gameObject.GetComponent<shar>().bigvin();
                shar.bigvinarm.text=p1.ToString();
            }
        }
    }
}
