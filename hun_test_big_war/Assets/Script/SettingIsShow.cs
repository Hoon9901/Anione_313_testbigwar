using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingIsShow: MonoBehaviour {
    private GameObject UI;
    private bool IsShow = false;

	// Use this for initialization
	void Start () {
        UI = GameObject.Find("Panel");
        UI.gameObject.SetActive(false);

	}
    public void OnMouseDown()
    {
        IsShow = !IsShow;
    }

	// Update is called once per frame
    void Update()
    {
        if (IsShow)
        {
            UI.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!IsShow)
        {
            UI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
