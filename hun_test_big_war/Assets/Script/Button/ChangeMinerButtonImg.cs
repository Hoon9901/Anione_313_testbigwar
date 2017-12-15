using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMinerButtonImg : MonoBehaviour {
    public int g_id;
    // Use this for initialization
    void Start()
    {
        switch (g_id)
        {
            case 0: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Miner1Button");
                break;
        }
        this.gameObject.transform.GetChild(1).GetComponent<Text>().text = GameObject.Find("Main Camera").GetComponent<MinerSpawn>().miner[MyInfo.minerID].GetComponent<Miner>().price.ToString() + " 원";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
