using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour {
    private GameObject SettingUI;
    private GameObject SettingBtn;
    private GameObject DarkBG;
    private bool IsShow = false;
	// Use this for initialization
	void Awake () {
        SettingUI = GameObject.Find("SettingPanel");
        SettingUI.gameObject.SetActive(false);
        DarkBG = GameObject.Find("DarkBG");
        DarkBG.SetActive(false);
    }
    public void OnMouseDown()
    {
        IsShow = !IsShow;
        DarkBG.SetActive(IsShow);
        if (IsShow)
        {
            GameObject.Find("Main Camera").GetComponent<CameraMove>().isMove = !IsShow;
            SettingUI.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!IsShow)
        {
            GameObject.Find("Main Camera").GetComponent<CameraMove>().isMove = !IsShow;
            SettingUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public bool GetIsShow()
    {
        return IsShow;
    }
	// Update is called once per frame
	void Update () {
	}
}
