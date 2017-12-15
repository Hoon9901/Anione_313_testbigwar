using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectHero : MonoBehaviour {
    public List<int> heroID;
    public int[] selectHero;
    public int[] banPick;
    public int turn;
    public Vector3 firstHPB;
    public Vector3 firstEPB;
    void Awake()
    {
        selectHero = new int[8];
        for (int i = 0; i < 8; i++) selectHero[i] = -1; 
    }
    public void setHeroSetting()
    {
        Vector3 firstLoc = new Vector3(-307.0f, 494.0f, 0.0f);
        heroID = new List<int>();
        for (int i = 0; i < MyInfo.hero.Count; i++)
        {
            heroID.Add(MyInfo.hero[i].id);
        }
        heroID.Sort();
        for (int i = 0; i < heroID.Count; i++)
        {
            Vector3 tempLoc = firstLoc;
            GameObject temp = GameObject.Find("HeroButton").transform.GetChild(heroID[i]).gameObject;
            tempLoc.x = firstLoc.x + (321 * (i % 3));
            tempLoc.y = firstLoc.y - (267 * (i / 3));
            temp.SetActive(true);
            temp.transform.localPosition = tempLoc;
        }
    }
	
    public void onActiveScreen(int[] banPick)
    {
        GameObject.Find("SelectHeroUI").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("SelectHeroUI").transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("onActiveScreen()");
        GameObject.Find("BanPickUI").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("BanPickUI").transform.GetChild(3).gameObject.SetActive(false);
        setHeroSetting();
        this.banPick = banPick;
        firstHPB = new Vector3(-886, 440, 0);
        firstEPB = new Vector3(877, 440, 0);
        setHeroColor(banPick[0], new Color(255 / 255, 137 / 255, 137 / 255));
        setHeroColor(banPick[1], new Color(255 / 255, 137 / 255, 137 / 255));
        GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("TurnNotice").transform.GetChild(0).GetComponent<Text>().text = "모험가 님이 영웅을 선택 중입니다.";
    }
    public void setHeroSelectPick(int id)
    {
        Color selectColor = new Color(107.0f / 255.0f, 255.0f / 255.0f, 195.0f / 255.0f);
        Color normalColor = new Color(255 / 255, 255 / 255, 255 / 255);
        if (turn % 2 == 1) return;
        for (int i = 0; i < 2; i++ )
        {
            if (id == banPick[i]) return;
        }
        for (int i = 0; i < turn / 2; i++)
        {
            if (selectHero[(i * 2)] == id)
                return;
        }
        if (selectHero[turn] != -1)
            setHeroColor(selectHero[turn], normalColor);
        selectHero[turn] = id;
        setHeroColor(selectHero[turn], selectColor);
    }
    public void setHeroImage(GameObject obj, int id)
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
    public void setHeroColor(int id, Color color)
    {
         GameObject.Find("HeroButton").transform.GetChild(id).GetComponent<Image>().color = color; 
    }
    public void completeHeroPick()
    {
        if (selectHero[turn] == -1) return;
        string name = "user_Pick" + (turn / 2 + 1);
        setHeroImage(GameObject.Find(name), selectHero[turn]);
        setHeroColor(selectHero[turn], new Color(50.0f / 255.0f, 50.0f / 255.0f, 50.0f / 255.0f));
        GameObject.Find("CompleteHeroPick").SetActive(false);
        turn++;
        System.Random r = new System.Random();
        StartCoroutine(NextStage(r.Next(2, 5)));
        Vector3 temp = new Vector3(firstHPB.x, firstHPB.y - 260 * (turn / 2 + 1), 0);
        GameObject.Find("UI").transform.GetChild(0).transform.localPosition = temp;
        GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(true);

        GameObject.Find("TurnNotice").transform.GetChild(0).GetComponent<Text>().text = "알파1 님이 영웅을 선택 중입니다.";
    }

    IEnumerator NextStage(float waitTime)
    {
        int count = 0;
        yield return new WaitForSeconds(waitTime);
        string name = "enemy_Pick" + (turn / 2 + 1);
        System.Random r = new System.Random();
        selectHero[turn] = r.Next(0, 12);
        while (true)
        {
            if (banPick[0] != selectHero[turn] && banPick[1] != selectHero[turn])
            {
                Debug.Log("진입");
                for (int i = 0; i < turn / 2; i++)
                {
                    if (selectHero[(i * 2 + 1)] != selectHero[turn])
                    {
                        count++;
                    }
                }
                Debug.Log("count : " + count);
                if (count >= turn / 2)
                {
                    break;
                }
            }
            count = 0;
            selectHero[turn] = r.Next(0, 12);
        }

        setHeroImage(GameObject.Find(name), selectHero[turn]);
        if (turn == 7)
        {
            GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("TurnNotice").transform.GetChild(0).GetComponent<Text>().text = "게임을 시작합니다.";
            StartCoroutine(CountDown(5));
        }
        else
        {
            Vector3 temp = new Vector3(firstEPB.x, firstEPB.y - 260 * (turn / 2 + 1), 0);
            GameObject.Find("UI").transform.GetChild(1).transform.localPosition = temp;
            GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("UI").transform.GetChild(1).gameObject.SetActive(false);
            turn++;
            GameObject.Find("SelectHeroUI").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("TurnNotice").transform.GetChild(0).GetComponent<Text>().text = "모험가 님이 영웅을 선택 중입니다.";
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CountDown(int count)
    {
        int temp = count;
        while (temp != -1)
        {
            yield return new WaitForSeconds(1);
            if (temp <= 3)
                GameObject.Find("TurnNotice").transform.GetChild(0).GetComponent<Text>().text = "[ " + temp + " ]";
            temp--;
        }
        yield return new WaitForSeconds(1);

        MyInfo.settingHero = new List<HeroInfo>();
        StageInfo.enemyID = new List<HeroInfo>();
        for (int i = 0; i < 4; i++)
        {
            MyInfo.settingHero.Add(new HeroInfo(selectHero[i*2], 0));
            StageInfo.enemyID.Add(new HeroInfo(selectHero[i * 2 + 1], 0));
        }
        SceneManager.LoadScene("Stage1");
    }
}
