using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDescription
{
    private string title;
    private string body;
    private string img;

    public DataDescription(string title, string body, string img)
    {
        this.title = title;
        this.body = body;
        this.img = img;
    }

    public string getTitle(){
        return this.title;
    }

    public string getBody(){
        return this.body;
    }

    public string getImg(){
        return this.img;
    }

    public void setImg(string img){
        this.img = img;
    }

    public void setBody(string body){
        this.body = body;
    }

    public void setTitle(string title){
        this.title = title;
    }
}   
