using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalClick : MonoBehaviour {
    public GameObject BuyCheckBox;
    public Text Price;
    public Text Price2;
    private Text CBPrice;
    private Sprite Icon;
    private Image BoxIcon;
    private GameObject DarkBG2;
    //
    public int _selCrystalNum = -1;
    public bool IsShow = false;
	// Use this for initialization
	void Start () {
        DarkBG2 = GameObject.Find("Store").transform.FindChild("DarkBG2").gameObject;
        BuyCheckBox = GameObject.Find("Store").transform.FindChild("BuyCheckBox").gameObject;
	}

    public void Click()
    {
        if (_selCrystalNum != -1)
        {
            StoreState.selCrystalNum = _selCrystalNum;
            StoreState.InitSel((int)StoreState.selobjState.Crystal);
            // Init
            Price = transform.FindChild("Price").GetComponent<Text>();
            Price2 = transform.FindChild("Text (1)").GetComponent<Text>();
            CBPrice = BuyCheckBox.transform.FindChild("Price").GetComponent<Text>();
            Icon = transform.FindChild("골드 이미지").GetComponent<Image>().sprite;
            BoxIcon = BuyCheckBox.transform.FindChild("MoenyIcon").GetComponent<Image>();
            //
            CBPrice.text = Price.text.ToString();
            BoxIcon.sprite = Icon;
            IsShow = !IsShow;
            if (IsShow)
            {
                DarkBG2.SetActive(IsShow);
                BuyCheckBox.SetActive(IsShow);
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
