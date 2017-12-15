using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextInStage : MonoBehaviour {
    public string mState; // Crystal , Coin 둘중 하나로
	// Use this for initialization
    Text moneyLabel;

    void Awake()
    {
        moneyLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mState == "Crystal")
        {

        }
        moneyLabel.text = StageInfo.g_Money[0].ToString();
    }
}
