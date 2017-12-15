using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPackClick : MonoBehaviour {
    private GameObject BuyCheckBox;
    public Text Price;
    private Text CheckBoxPrice;
    private Sprite Icon;
    private Image boxIcon;
    private GameObject DarkBG2;

    public int selpackNum_ = -1;
    public string moneyState;
    public bool IsShow = false;
	// Use this for initialization
	void Start () {
        DarkBG2 = GameObject.Find("Store").transform.FindChild("DarkBG2").gameObject;
        BuyCheckBox = GameObject.Find("Store").transform.FindChild("BuyCheckBox").gameObject;
      	}

    public void OnMouseDown()
    {
        if (selpackNum_ != -1)
        {
            StoreState.selpackNum = selpackNum_;
            StoreState.InitSel((int)StoreState.selobjState.Pack);

            Debug.Log(StoreState.selpackNum + " " + StoreState.selgoldNum);

            // Init
            Price = transform.FindChild("Text").GetComponent<Text>();
            CheckBoxPrice = BuyCheckBox.transform.FindChild("Price").GetComponent<Text>();
            Icon = transform.FindChild("Icon").GetComponent<Image>().sprite;
            //
            CheckBoxPrice.text = Price.text.ToString();
            boxIcon = BuyCheckBox.transform.FindChild("MoenyIcon").GetComponent<Image>();
            boxIcon.sprite = Icon;
            IsShow = !IsShow;
            if (IsShow)
            {
                DarkBG2.SetActive(IsShow);
                BuyCheckBox.SetActive(IsShow);
                CheckBoxPrice.text = Price.text.ToString();
            }
            else if (!IsShow)
            {
                DarkBG2.SetActive(IsShow);
                BuyCheckBox.SetActive(IsShow);
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
