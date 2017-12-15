using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CBButton : MonoBehaviour {
    public float price;
	// Use this for initialization
	void Start () {
        GameObject.Find("BuyCheckBox").SetActive(false);
	}

    public void BuyClick()
    {// 영웅팩 뽑기
        if (StoreState.selgoldNum == -1 &&StoreState.selpackNum != -1)
        {
            string oPrice = GameObject.Find("HeroPack View").transform.FindChild("HeroPack Content")
            .transform.FindChild("hero " + StoreState.selpackNum.ToString()).GetComponent<HeroPackClick>().Price.text;
            string mState = GameObject.Find("HeroPack View").transform.FindChild("HeroPack Content")
            .transform.FindChild("hero " + StoreState.selpackNum.ToString()).GetComponent<HeroPackClick>().moneyState;

            oPrice = Regex.Replace(oPrice, @"\D", "");
            price = float.Parse(oPrice);
            if (mState == "Coin")
            {
                if (MyInfo_db.instance.money >= price)
                {
                    MyInfo_db.instance.money -= price;
                    GameObject.Find("BuyCheckBox").SetActive(false);
                    GameObject.Find("Store").transform.FindChild("CardOpen").gameObject.SetActive(true);
                }
            }
            else if (mState == "Crystal")
            {
                if (MyInfo_db.instance.crystal >= price)
                {
                    MyInfo_db.instance.crystal -= price;
                    GameObject.Find("BuyCheckBox").SetActive(false);
                    GameObject.Find("Store").transform.FindChild("CardOpen").gameObject.SetActive(true);
                }
            }
            else if (mState == "Free")
            {
                Debug.Log("무료 ");
            }
        }// 크리스탈 구매
        else if (StoreState.selgoldNum != -1 && StoreState.selpackNum == -1)
        {
            string oringPrice = GameObject.Find("Gold View").transform.FindChild("Gold Content")
                .transform.FindChild("Gold " + StoreState.selgoldNum.ToString()).GetComponent<GoldClick>().Price.text;
            string newPrice = GameObject.Find("Gold View").transform.FindChild("Gold Content")
            .transform.FindChild("Gold " + StoreState.selgoldNum.ToString()).GetComponent<GoldClick>().Price2.text;

            oringPrice = Regex.Replace(oringPrice, @"\D", "");
            price = float.Parse(oringPrice);
            newPrice = Regex.Replace(newPrice, @"\D", "");
            if (MyInfo_db.instance.crystal >= price)
            {

                MyInfo_db.instance.money += float.Parse(newPrice);
                MyInfo_db.instance.crystal -= price;
            }
        }    
    }

    public void ExitClick()
    {
        if (StoreState.selpackNum != -1 && StoreState.selgoldNum == -1)
        {
            GameObject.Find("HeroPack View").transform.FindChild("HeroPack Content")
            .transform.FindChild("hero " + StoreState.selpackNum.ToString()).GetComponent<HeroPackClick>().IsShow = false;
        }
        else if (StoreState.selpackNum == -1 && StoreState.selgoldNum != -1)
        {
            GameObject.Find("Gold View").transform.FindChild("Gold Content")
            .transform.FindChild("Gold " + StoreState.selgoldNum.ToString()).GetComponent<GoldClick>().IsShow = false;
        }
        GameObject.Find("BuyCheckBox").SetActive(false);
        GameObject.Find("Store").transform.FindChild("DarkBG2").gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
