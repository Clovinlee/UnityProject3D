using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ObjectClick : MonoBehaviour
{

    public GameObject descriptionPanel;
    private Animator an;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {

        if(EventSystem.current.IsPointerOverGameObject() || GameState.objActive != null || Freedom.cekDistance(gameObject)){
            return;
        }

        GameState.objActive = gameObject;
        AudioSource asource = gameObject.GetComponent<AudioSource>();
        asource.Play();
        an.SetInteger("move",1);
        Freedom.f = false;
        StartCoroutine(waitForAnim(an.GetCurrentAnimatorStateInfo(0).length+0.5f));
        
    }

    // StartCoroutine(closeDescriptionPanel(0.15f));

    IEnumerator waitForAnim(float time)
    {
        yield return new WaitForSeconds(time);
        changeText(descriptionPanel, DataDescription.listData[id]);
        Freedom.pointer.SetActive(false);
        descriptionPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        // panelDescription.SetActive(false);
    }

    public void changeText(GameObject pl, DataDescription data){
        TextMeshProUGUI txtTitle = pl.transform.Find("txtTitle").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI txtBody = pl.transform.Find("txtBody").GetComponent<TextMeshProUGUI>();
        Image imgObject = pl.transform.Find("imgObject").GetComponent<Image>();

        txtTitle.text = data.getTitle();
        txtBody.text = data.getBody();
        imgObject.sprite = Resources.Load<Sprite>(data.getImg());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
