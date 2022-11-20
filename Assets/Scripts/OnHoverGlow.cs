using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverGlow : MonoBehaviour
{
    // Start is called before the first frame update
    private int s;
    void Start()
    {
        
    }

    void OnMouseEnter()
    {
        Outline ot = this.gameObject.GetComponent<Outline>();
        ot.OutlineWidth = 5;
        
        if(transform.childCount > 0){
            //gameObject has Children
            foreach (Transform child in transform)
            {   
                Outline otChild = child.GetComponent<Outline>();
                if(otChild != null){
                    otChild.OutlineWidth = 5;
                }
            }
        }
    }

    void OnMouseExit()
    {
        Outline ot = this.gameObject.GetComponent<Outline>();
        ot.OutlineWidth = 0;

        if(transform.childCount > 0){
            //gameObject has Children
            foreach (Transform child in transform)
            {   
                Outline otChild = child.GetComponent<Outline>();
                if(otChild != null){
                    otChild.OutlineWidth = 0;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
