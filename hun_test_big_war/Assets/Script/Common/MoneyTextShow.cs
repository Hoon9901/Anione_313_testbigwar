using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyTextShow : MonoBehaviour
{
    Text moneyLabel;
    public string moneyState;
    void Awake()
    {
        moneyLabel = GetComponent<Text>();   
    }
	
	// Update is called once per frame
	void Update () {
        if (moneyState == "Crystal")
        {
            moneyLabel.text = MyInfo.crystal.ToString();
        }
        else
        {
            moneyLabel.text = MyInfo.money.ToString();
        }
	}
}
