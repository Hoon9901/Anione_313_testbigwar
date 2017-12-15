using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EachCardInit : MonoBehaviour
{
    public float[] f_Probability;
    public float[] eachCard_Probability_Ref;
    public int unitSize = 0;
    public int[] unit;
    public GameObject[] allshow_cards;
    float Choose(float[] probs) // 확률
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    public int gradeRandom(int igrade) // 등급에 따른 유닛 뽑기 함수
    {
        int temp;
        switch (igrade)
        {   // 등급
            case (int)Grade_Enum.Silver:
                temp = Random.Range((int)object_id.선인장, (int)object_id.엘 + 1);
                return temp;
            case (int)Grade_Enum.Gold:
                temp = Random.Range((int)object_id.핑크빈, (int)object_id.루피 + 1);
                return temp;
            case (int)Grade_Enum.Diamond:
                switch (Random.Range((int)object_id.번개, (int)object_id.타마마 + 1))
                {
                    case (int)object_id.번개:
                        break;
                    case (int)object_id.타마마:
                        break;
                }
                break;
            case (int)Grade_Enum.Challenger:
                switch (Random.Range((int)object_id.눈사람, (int)object_id.내면+ 1))
                {
                    case (int)object_id.눈사람:
                        break;
                    case (int)object_id.내면:
                        break;
                }
                break;
                temp = Random.Range((int)object_id.번개, (int)object_id.타마마 + 1);
                return temp;
        }
        return -1;
    }

    public void EachInit()
    {
        Debug.Log(Summon_Manager.cardP.Length);
        for (int i = 0; i < Summon_Manager.cardP.Length; i++)
        {
            Summon_Manager.cardP[i] = Choose(f_Probability);
        }
        eachCard_Probability_Ref = (float[])Summon_Manager.cardP.Clone();
    }

    public void AllInit()
    {
        int[] unit_count = new int[13];
        for (int i = 0; i < 13; i++)
        {
            unit_count[i] = 0;
        }

        for (int i = 0; i < 10 * 5; i++)
        {
            int temp = (int)Choose(f_Probability); // 확률 뽑기

            MyInfo_db.instance.MyInfo_cardUnit_val_Load(gradeRandom(temp)); // 싱글턴 객체에 temp를 넘겨줌
            switch (gradeRandom(temp))
            {
                case (int)object_id.선인장:
                    unit_count[0]++;
                    break;
                case (int)object_id.나루토:
                    unit_count[1]++;
                    break;
                case (int)object_id.징징이:
                    unit_count[2]++;
                    break;
                case (int)object_id.나미:
                    unit_count[3]++;
                    break;
                case (int)object_id.키리토:
                    unit_count[4]++;
                    break;
                case (int)object_id.엘:
                    unit_count[5]++;
                    break;
                case (int)object_id.핑크빈:
                    unit_count[6]++;
                    break;
                case (int)object_id.사스케:
                    unit_count[7]++;
                    break;
                case (int)object_id.루피:
                    unit_count[8]++;
                    break;
                case (int)object_id.번개:
                    unit_count[9]++;
                    break;
                case (int)object_id.타마마:
                    unit_count[10]++;
                    break;
                case (int)object_id.눈사람:
                    unit_count[11]++;
                    break;
                case (int)object_id.내면:
                    unit_count[12]++;
                    break;
            }
        }
        for (int i = 0; i < 13; i++)
        {
            MyInfo_db.instance.cardUnit_count[i] += unit_count[i];
            if (unit_count[i] > 0)
            {
                allshow_cards[i].GetComponentInChildren<Text>().text = "x " + unit_count[i].ToString();
                Color temp = allshow_cards[i].GetComponent<Image>().color;
                allshow_cards[i].GetComponent<Image>().color = new Color(temp.r, temp.g, temp.b, 1);
            }
        }
        
    }

    public void AllOpen()
    {
        int[] unit_count = new int[13];
        for (int i = 0; i < 13; i++)
        {
            unit_count[i] = 0;
        }

        for (int i = 0; i < Summon_Manager.cardPack * 5; i++)
        {
            int temp = (int)Choose(f_Probability); // 확률 뽑기

            MyInfo_db.instance.MyInfo_cardUnit_val_Load(gradeRandom(temp)); // 싱글턴 객체에 temp를 넘겨줌
            switch (gradeRandom(temp))
            {
                case (int)object_id.선인장:
                    unit_count[0]++;
                    break;
                case (int)object_id.나루토:
                    unit_count[1]++;
                    break;
                case (int)object_id.징징이:
                    unit_count[2]++;
                    break;
                case (int)object_id.나미:
                    unit_count[3]++;
                    break;
                case (int)object_id.키리토:
                    unit_count[4]++;
                    break;
                case (int)object_id.엘:
                    unit_count[5]++;
                    break;
                case (int)object_id.핑크빈:
                    unit_count[6]++;
                    break;
                case (int)object_id.사스케:
                    unit_count[7]++;
                    break;
                case (int)object_id.루피:
                    unit_count[8]++;
                    break;
                case (int)object_id.번개:
                    unit_count[9]++;
                    break;
                case (int)object_id.타마마:
                    unit_count[10]++;
                    break;
                case (int)object_id.눈사람:
                    unit_count[11]++;
                    break;
                case (int)object_id.내면:
                    unit_count[12]++;
                    break;
            }
        }
        for (int i = 0; i < 13; i++)
        {
            MyInfo_db.instance.cardUnit_count[i] += unit_count[i];
            if (unit_count[i] > 0)
            {
                allshow_cards[i].GetComponentInChildren<Text>().text = "x " + unit_count[i].ToString();
                Color temp = allshow_cards[i].GetComponent<Image>().color;
                allshow_cards[i].GetComponent<Image>().color = new Color(temp.r, temp.g, temp.b, 1);
            }
        }
        Summon_Manager.bAllOpen = true;
        GameObject.Find("Cards").SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("AllShow").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("Exit").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.FindChild("MoreOpen").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.FindChild("AllOpen").gameObject.SetActive(false);
    }

    public void MoreOpen()
    {
        Debug.Log("Summon_Manager.cardPack : " + Summon_Manager.cardPack);
        Application.LoadLevel("Summon_Mobile_Scene");
    }

    // Use this for initialization
    void Awake()
    {
        Init_AllShow_Cards();
        if (Summon_Manager.bAllOpen)
        {
            GameObject.Find("Canvas").transform.FindChild("AllShow").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.FindChild("Exit").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.FindChild("MoreOpen").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("AllOpen").gameObject.SetActive(false);
            for (int i = 0; i < 5; i++)
            {
                GameObject.Find("Card " + i).SetActive(false);
            }
            AllInit();
        }
        else
        {
            EachInit();
            // 씬에 관한 켄버스 옵젝 초기화
            GameObject.Find("Canvas").transform.FindChild("AllShow").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("Exit").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("MoreOpen").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.FindChild("AllOpen").gameObject.SetActive(false);
        }
    }

    void Init_AllShow_Cards()
    {
        for (int i = 0; i < 13; i++)
        {
            allshow_cards[i].GetComponentInChildren<Text>().text = "x " + "0";
            Color colortemp = allshow_cards[i].GetComponent<Image>().color;
            allshow_cards[i].GetComponent<Image>().color = new Color(colortemp.r, colortemp.g, colortemp.b, 0.4f);
        }
    }

    public void ClickExit()
    {
        Application.LoadLevel(Summon_Manager.lastStageLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
