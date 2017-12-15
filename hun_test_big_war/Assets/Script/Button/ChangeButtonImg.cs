using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonImg : MonoBehaviour {
    public int g_loc;
	// Use this for initialization
	void Start () {
        if (g_loc > StageInfo.heroSetting.Count)  {
            Debug.Log("Loc 수치 오류!!!!");  return;
        }

        switch (StageInfo.heroSetting[g_loc].id) {
            case 0: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Squidward_Button");
                break;
            case 1: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/PinkBin_Button");
                break;
            case 2: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Deo_Button");
                break;
            case 3: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/InnerRage_Button");
                break;
            case 4: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Kirito_Button");
                break;
            case 5: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Luffy_Button");
                break;
            case 6: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Nami_Button");
                break;
            case 7: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Tamama_Button");
                break;
            case 8: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Sasuke_Button");
                break;
            case 9: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Naruto_Button");
                break;
            case 10: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/L_Button");
                break;
            case 11: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Misaka_Button");
                break;
            case 12: this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/NooNoo_Button");
                break;
        }
        this.gameObject.transform.GetChild(1).GetComponent<Text>().text = StageInfo.heroSetting[g_loc].price.ToString() + " 원";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
