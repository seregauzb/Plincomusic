using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class easyrenderer : MonoBehaviour
{
    public GameObject g1,g2,g3;
    byte c=0,a;
    // Start is called before the first frame update
    void Start()
    {
        a=byte.Parse(File.ReadAllText(Application.persistentDataPath + "/qozi.txt")); 
        switch(a){
            case 0:easy();break;
            case 1:medium();break;
            case 2:hard();break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(a!=c){
            switch(a){
            case 0:easy();break;
            case 1:medium();break;
            case 2:hard();break;
        }
        a=c;
        }
    }
    public void easy(){
        g1.SetActive(true);
        g2.SetActive(false);g3.SetActive(false);

    }
    public void medium(){
        g1.SetActive(false);
        g2.SetActive(true);g3.SetActive(false);
    }
    public void hard(){
        g1.SetActive(false);
        g2.SetActive(false);g3.SetActive(true);
    }
}
