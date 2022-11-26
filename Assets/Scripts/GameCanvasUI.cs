using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject panelForensic;
    public GameObject panelDescription;
    public AudioClip paperSound;
    public AudioClip clickSound;
    public GameObject pointer;

    private AudioSource asource;

    void Start()
    {
        asource = gameObject.GetComponent<AudioSource>();
    }

    public void forensicButtonPress(){
        asource.clip = paperSound;
        asource.Play();
        Freedom.f = panelForensic.activeInHierarchy;
        panelForensic.SetActive(!panelForensic.activeInHierarchy);
    }

    public void descriptionButtonClose(){
        StartCoroutine(closeDescriptionPanel(0.15f));
    }

    IEnumerator closeDescriptionPanel(float time)
    {
        yield return new WaitForSeconds(time);
        GameState.objActive.GetComponent<Animator>().SetInteger("move",0);
        GameState.objActive = null;
        panelDescription.SetActive(false);
        Freedom.f = true;
        pointer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("tab")){
            if(panelForensic != null){
                forensicButtonPress();
            }
        }
    }
}
