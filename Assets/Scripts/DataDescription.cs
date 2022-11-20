using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDescription
{
    private string title;
    private string body;
    private string img;
    private int id;

    public static List<DataDescription> listData = new List<DataDescription>(){
        new DataDescription(0,"Bucket","Just an ordinary bucket with nothing special","victim"),
        new DataDescription(1,"Tissue","Its a white tissue","imageHose"),
    };

    public DataDescription(int id, string title, string body, string img)
    {
        this.id = id;
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
