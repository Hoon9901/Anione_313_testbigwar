using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banpick : MonoBehaviour {
    public int[] banpick;
    void Awake()
    {
        banpick = new int[2];
        banpick[0] = -1;
    }

    public void setBanImage(GameObject obj, int id)
    {
        switch (id)
        {
            case 0: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Squidward_Button");
                break;
            case 1: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/PinkBin_Button");
                break;
            case 2: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Deo_Button");
                break;
            case 3: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/InnerRage_Button");
                break;
            case 4: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Kirito_Button");
                break;
            case 5: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Luffy_Button");
                break;
            case 6: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Nami_Button");
                break;
            case 7: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Tamama_Button");
                break;
            case 8: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Sasuke_Button");
                break;
            case 9: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Naruto_Button");
                break;
            case 10: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/L_Button");
                break;
            case 11: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/Misaka_Card");
                break;
            case 12: obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Button/NooNoo_Button");
                break;
        }
    }
    public void setBanColor(int id, Color color)
    {
        GameObject.Find("BanButton").transform.GetChild(id).GetComponent<Image>().color = color; 
    }
    public void setHeroBanPick(int id)
    {
        Color banColor = new Color(255/255, 137/255, 137/255);
        Color normalColor = new Color(255/255, 255/255, 255/255);
        if (banpick[0] != -1)
            setBanColor(banpick[0], normalColor);
        banpick[0] = id;
        setBanColor(banpick[0], banColor);
    }

    public void completeBanPick()
    {
        setBanImage(GameObject.Find("HeroBanImage"), banpick[0]);
        GameObject.Find("BanPickground").SetActive(false);
        GameObject.Find("CompleteBanPick").SetActive(false);
        System.Random r = new System.Random();
        GameObject.Find("TurnNotice").transform.GetChild(0).GetComponent<Text>().text = "알파1 님이 벤 영웅을 선택 중입니다.";
        StartCoroutine(NextStage(r.Next(3, 15)));
    }

    IEnumerator NextStage(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        System.Random r = new System.Random(); 
        banpick[1] = r.Next(0, 12);

        while (banpick[0] == banpick[1]) banpick[1] = r.Next(0, 12);
        setBanImage(GameObject.Find("EnemyBanImage"), banpick[1]);
        GameObject.Find("SelectHeroUI").GetComponent<SelectHero>().onActiveScreen(banpick);
    }
}
