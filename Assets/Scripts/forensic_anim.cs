using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forensic_anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onHover(){
        Animator an = gameObject.GetComponent<Animator>();
        an.SetInteger("forensic_hover",1);
    }

    public void onExit(){
        Animator an = gameObject.GetComponent<Animator>();
        an.SetInteger("forensic_hover",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
