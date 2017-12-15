using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardOpen : MonoBehaviour {
    private Image CardImg;
    public bool IsClicked;

	// Use this for initialization
	void Start () {
        Sprite img = GameObject.Find("HeroPack View").transform.FindChild("HeroPack Content").transform.
        FindChild("hero "+ StoreState.selpackNum.ToString()).transform.FindChild("Image").GetComponent<Image>().sprite;
        //
        CardImg = transform.FindChild("CardImg").GetComponent<Image>();
        CardImg.sprite = img;
        if (StoreState.selpackNum == 1 || StoreState.selpackNum == 3)
        {
            transform.FindChild("Each Open").gameObject.SetActive(true);
            transform.FindChild("All Open").gameObject.SetActive(true);
            transform.FindChild("Single Open").gameObject.SetActive(false);
            Summon_Manager.bIsMoreOpen = true;
            Summon_Manager.cardPack = 10;
        }
        else
        {
            transform.FindChild("Single Open").gameObject.SetActive(true);
            transform.FindChild("Each Open").gameObject.SetActive(false);
            transform.FindChild("All Open").gameObject.SetActive(false);
            Summon_Manager.bIsMoreOpen = false;
            Summon_Manager.cardPack = 1;
        }
	}

    public void EachOpen()
    {
        // OBJ 클릭됌
        IsClicked = true;
        Application.LoadLevel("Summon_Mobile_Scene");
        Summon_Manager.lastStageLevel = Application.loadedLevel;
        Time.timeScale = 1f;
        Summon_Manager.bAllOpen = false;
    }

    public void AllOpen()
    {
        IsClicked = true;
        Application.LoadLevel("Summon_Mobile_Scene");
        Summon_Manager.lastStageLevel = Application.loadedLevel;
        Time.timeScale = 1f;
        Summon_Manager.bAllOpen = true;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
