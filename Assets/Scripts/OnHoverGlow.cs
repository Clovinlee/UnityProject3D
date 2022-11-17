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
        Debug.Log("MOUSE ENTER");
        Outline ot = this.gameObject.GetComponent<Outline>();
        ot.OutlineWidth = 5;
    }

    void OnMouseExit()
    {
        Debug.Log("EXIT");
        Outline ot = this.gameObject.GetComponent<Outline>();
        ot.OutlineWidth = 0;
    }

    void Update()
    {
        
    }
}
