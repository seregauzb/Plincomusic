using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class musicrend : MonoBehaviour
{
    bool muzyon=true,ovyoq=true;
    public mmmuzcgange mch;
    public AudioSource buying;
    public string manzil;
    bool portlash=true;
    public Slider slider;
    float javob;

    // Start is called before the first frame update
    void Start()
    {
        if(File.ReadAllText(Application.persistentDataPath + manzil)==javob.ToString()){
            buying.volume=float.Parse(File.ReadAllText(Application.persistentDataPath + manzil));
            slider.value=float.Parse(File.ReadAllText(Application.persistentDataPath + manzil));
            portlash=false;
        }else{
            buying.volume=float.Parse(File.ReadAllText(Application.persistentDataPath + manzil));
            slider.value=float.Parse(File.ReadAllText(Application.persistentDataPath + manzil));
            portlash=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(portlash){
            Destroy(gameObject);
        }
        if(mch!=null){
            buying=mch.asu;
        }
        javob=slider.value;
        buying.volume=(javob);
    }
    public void musicrender(){
            File.WriteAllText(Application.persistentDataPath + manzil,javob.ToString());
    }
}
