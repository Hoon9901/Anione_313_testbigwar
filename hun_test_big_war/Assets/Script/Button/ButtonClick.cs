using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        //GameObject.Find("DarkBG2").SetActive(false);
    }

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click_StageButton()
    {
        Application.LoadLevel(2);
    }
    public void Click_HomeButton()
    {
        Application.LoadLevel(1);
    }
    public void Click_goto_StageSel()
    {
        Application.LoadLevel(3);
    }
    public void All_Data_Reset()
    {
        MyInfo_db.instance.MyInfo_reset_All_Data();
    }
    public void Click_MyRoom()
    {
        Application.LoadLevel("MyScene");
    }
}
