using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {
    public bool bIsButton = false;
	// Use this for initialization
	void Start () {
	}
 
    void OnMouseDown()
    {
        if (this.tag == "ExitButton")
        {
            Debug.logger.Log(this.tag + "Actvite");
            Application.Quit();
        }

        if (this.tag == "StartButton")
        {
            Application.LoadLevel("MainScene");
        }
        if (this.tag == "StageButton")
        {
            Debug.logger.Log(this.tag +"Actvite");
        }
        if (this.tag == "StoreButton")
        {
            Debug.logger.Log(this.tag + "Actvite");
        }
        if (this.name == "시나리오문")
        {
            Application.LoadLevel("StageSelectScene");
        }
        if (this.name == "Stage1")
        {
            Application.LoadLevel("Stage1");
        }
    }

    void OnHover(bool isOver)
    {
        if (bIsButton)
        {
            this.transform.localScale = (isOver) ? Vector2.one * 1.2f : Vector2.one; 
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
	}
}
