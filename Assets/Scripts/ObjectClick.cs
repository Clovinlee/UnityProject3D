using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectClick : MonoBehaviour
{

    public GameObject descriptionPanel;
    public string txtTitle;
    public string txtBody;
    public string txtImg;

    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        DataDescription d = new DataDescription(txtTitle,txtBody,txtImg);
        changeText(descriptionPanel, d);
        //TODO : ANimation + click + panel
        AudioSource asource = gameObject.GetComponent<AudioSource>();
        asource.Play();
        descriptionPanel.SetActive(true);
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
