using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject panelGame;

    void Start()
    {
        
    }

    public void forensicButtonPress(){
        panelGame.SetActive(!panelGame.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(panelGame != null && panelGame.activeInHierarchy){
                forensicButtonPress();
            }
        }
    }
}
