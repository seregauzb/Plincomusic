using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoqqil : MonoBehaviour
{
    float sanoq=2;
    public byte sansan=2;
    // Start is called before the first frame update
    void Start()
    {
        sanoq=sansan;
    }

    // Update is called once per frame
    void Update()
    {
        if(sanoq>0){
            sanoq-=Time.deltaTime;
        }else{
            sanoq=sansan;
            gameObject.SetActive(false);
        }
    }
}
