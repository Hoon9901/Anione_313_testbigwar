using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour {
    private GameObject Store;
    private GameObject DarkBG;

    private bool IsShow = false;
	// Use this for initialization
	void Awake () {
        Store = GameObject.Find("Store");
        Store.SetActive(false);
        DarkBG = GameObject.Find("Canvas").transform.FindChild("DarkBG").gameObject;
        GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("DarkBG2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("CardOpen").gameObject.SetActive(false);

	}
    public void OnMouseDown()
    {
        IsShow = !IsShow;
        if (IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            DarkBG.SetActive(IsShow);
            //Time.timeScale = 0f;
        }
        else if(!IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            DarkBG.SetActive(IsShow);
            //Time.timeScale = 1f;
        }
    }

    public void Test_Mobile_store()
    {
        Summon_Manager.lastStageLevel = Application.loadedLevel;
        Application.LoadLevel("Summon_Mobile_Scene");
    }

    public void goMoneyView()
    {
        IsShow = !IsShow;
        if (IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("HeroPack View").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("Crystal View").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("Gold View").gameObject.SetActive(true);
            DarkBG.SetActive(IsShow);
            //Time.timeScale = 0f;
        }
        else if (!IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            DarkBG.SetActive(IsShow);
            //Time.timeScale = 1f;
        }
    }

    public void goHeroPackView()
    {
        IsShow = !IsShow;
        if (IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("HeroPack View").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("Gold View").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("Crystal View").gameObject.SetActive(false);
            DarkBG.SetActive(IsShow);
            //Time.timeScale = 0f;
        }
        else if (!IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            DarkBG.SetActive(IsShow);
            // Time.timeScale = 1f;
        }
    }

    public void goCrystalView()
    {
        IsShow = !IsShow;
        if (IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("HeroPack View").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("Gold View").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("Store").transform.FindChild("Crystal View").gameObject.SetActive(true);
            DarkBG.SetActive(IsShow);
            //Time.timeScale = 0f;
        }
        else if (!IsShow)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMove>().isMove = !IsShow;
            Store.SetActive(IsShow);
            DarkBG.SetActive(IsShow);
           // Time.timeScale = 1f;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
