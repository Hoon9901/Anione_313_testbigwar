using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myroom_Button_Click : MonoBehaviour {
    void Awake()
    {
        MyRoom_Manager.currentView = (int)MyRoom_Manager.view_id.Silver;
        if (MyRoom_Manager.currentView == (int)MyRoom_Manager.view_id.Silver)
        {
            GameObject.Find("UI").transform.FindChild("Gold View").gameObject.SetActive(false);
            GameObject.Find("UI").transform.FindChild("Silver View").gameObject.SetActive(true);
            GameObject.Find("UI").transform.FindChild("Diamond View").gameObject.SetActive(false);
            GameObject.Find("UI").transform.FindChild("Challenger View").gameObject.SetActive(false);
        }


    }
    public void Exit()
    {
        Application.LoadLevel("MainScene");
    }
    public void GoldView()
    {
        MyRoom_Manager.currentView = (int)MyRoom_Manager.view_id.Gold;
        GameObject.Find("UI").transform.FindChild("Gold View").gameObject.SetActive(true);
        GameObject.Find("UI").transform.FindChild("Silver View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Diamond View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Challenger View").gameObject.SetActive(false);
    }
    public void SilverView()
    {
        MyRoom_Manager.currentView = (int)MyRoom_Manager.view_id.Silver;
        GameObject.Find("UI").transform.FindChild("Silver View").gameObject.SetActive(true);
        GameObject.Find("UI").transform.FindChild("Gold View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Diamond View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Challenger View").gameObject.SetActive(false);
    }

    public void DiamondView()
    {
        MyRoom_Manager.currentView = (int)MyRoom_Manager.view_id.Diamond;
        GameObject.Find("UI").transform.FindChild("Silver View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Gold View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Diamond View").gameObject.SetActive(true);
        GameObject.Find("UI").transform.FindChild("Challenger View").gameObject.SetActive(false);
    }
    public void ChallengerView()
    {
        MyRoom_Manager.currentView = (int)MyRoom_Manager.view_id.Challenger;
        GameObject.Find("UI").transform.FindChild("Silver View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Gold View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Diamond View").gameObject.SetActive(false);
        GameObject.Find("UI").transform.FindChild("Challenger View").gameObject.SetActive(true);
    }

}
