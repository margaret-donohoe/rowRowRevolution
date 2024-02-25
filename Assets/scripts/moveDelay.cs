using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moveDelay : MonoBehaviour
{

    private pInput p;
    private float iT;

    // Start is called before the first frame update
    void Start()
    {
        iT = (float)AudioSettings.dspTime;
        p = gameObject.GetComponent<pInput>();
        //p.enabled = false;
        //StartCoroutine(Begin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Begin()
    {
        
        
        yield return new WaitForSeconds(0.4f);
        //p.enabled = true;
    }
}
