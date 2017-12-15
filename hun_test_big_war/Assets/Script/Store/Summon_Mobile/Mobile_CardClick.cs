using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mobile_CardClick : MonoBehaviour {

    private GameObject Card;
    public int CardNum = -1;
    public int thisCardGrade;
    public bool bClicked = false;
    // Effect
    public GameObject gold_effect;
    public GameObject diamon_effect;
    public GameObject challenger_effect;

    public GameObject card_effect;
    bool effectDestroy = false;
    //


	// Use this for initialization
	void Start () {        
        Card = GameObject.Find("Card " + CardNum.ToString());
        thisCardGrade = (int)Summon_Manager.cardP[CardNum]; // temp 등급값을 받는다
        DetectGrade(thisCardGrade);
        Debug.Log("이 "+CardNum+"의 등급 :" + thisCardGrade);
	}

    void DetectGrade(int i_grade) // 등급에 따른 이펙트 생성
    {
        switch (i_grade)
        {
            case (int)Grade_Enum.Silver:
                card_effect = Instantiate(gold_effect, new Vector2(0, 0), transform.rotation);
                break;
            case (int)Grade_Enum.Gold:
                card_effect = Instantiate(gold_effect, new Vector2(0, 0), transform.rotation);
                break;
            case (int)Grade_Enum.Diamond:
                card_effect = Instantiate(diamon_effect, new Vector2(0, 0), transform.rotation);
                break;
            case (int)Grade_Enum.Challenger:
                card_effect = Instantiate(challenger_effect, new Vector2(0, 0), transform.rotation);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Summon Manager")
        {
            if (thisCardGrade != (int)Grade_Enum.Silver)
            {
                card_effect.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Summon Manager")
        {
            if (thisCardGrade != (int)Grade_Enum.Silver)
            {
                card_effect.SetActive(false);
            }
        }
    }
    public int gradeRandom_id(int igrade) // 등급을 -> 아이디와 변환 동시에 카드 모습 변경
    {
        int temp;
        switch (igrade)
        {   // 등급
            case (int)Grade_Enum.Silver:
                temp = Random.Range((int)object_id.선인장, (int)object_id.엘 + 1);
                switch (temp)
                {
                    case (int)object_id.선인장:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Deo_Card");
                        break;
                    case (int)object_id.나루토:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Naruto_Card");
                        break;
                    case (int)object_id.징징이:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Squidward_Card");
                        break;
                    case (int)object_id.나미:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Nami_Card");
                        break;
                    case (int)object_id.키리토:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Kirito_Card");
                        break;
                    case (int)object_id.엘:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/L_Card");
                        break;
                }
                Debug.Log("실버 이고 ID는 " + temp);
                return temp;
            case (int)Grade_Enum.Gold:
                temp = Random.Range((int)object_id.핑크빈, (int)object_id.루피 + 1);
                switch (temp)
                {
                    case (int)object_id.핑크빈:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Pinkbin_Card");
                        break;
                    case (int)object_id.사스케:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Sasuke_Card");
                        break;
                    case (int)object_id.루피:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Luffy_Card");
                        break;
                }
                Debug.Log("골드 이고 ID는 " + temp);
                return temp;
            case (int)Grade_Enum.Diamond:
                temp = Random.Range((int)object_id.번개, (int)object_id.타마마 + 1);
                switch (temp)
                {
                    case (int)object_id.번개:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Misaka_Card");
                        break;
                    case (int)object_id.타마마:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/Tamama_Card");
                        break;
                }
                Debug.Log("다이아몬드 이고 ID는 " + temp);
                return temp;
            case (int)Grade_Enum.Challenger:
                temp = Random.Range((int)object_id.눈사람, (int)object_id.내면 + 1);
                switch (temp)
                {
                    case (int)object_id.눈사람:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/NooNoo_Card");
                        break;
                    case (int)object_id.내면:
                        Card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/Cards/InnerRage_Card");
                        break;
                }
                Debug.Log("첼린저 이고 ID는 " + temp);
                return temp;
        }
        return -1;
    }

    public void OnMouseDown()
    {
        if (this.name.Equals("Card " + Summon_Manager.cardSel) && !bClicked)
        {
            Debug.Log("확률 : " + Summon_Manager.cardP[Summon_Manager.cardSel]);
            int temp_id;
            temp_id = gradeRandom_id(thisCardGrade);

            bClicked = true;
            Summon_Manager.cardClickTry++;
            Debug.Log("누른 횟수 " + Summon_Manager.cardClickTry);

            // temp를 DB에 넘겨줌
            MyInfo_db.instance.MyInfo_cardUnit_val_Load(temp_id);
            // 각 카드 누른거를 count하여 최대치가 되면 다시 개봉하거나 개봉종료 체크
            if (Summon_Manager.cardClickTry >= 5) // 다 개봉하면
            {
                if (Summon_Manager.bIsMoreOpen) // 팩 남으면
                {
                    if (Summon_Manager.cardPack != 1) // 카드백이 1개 초과 남으면
                    {
                        Summon_Manager.cardPack--;
                        GameObject.Find("Canvas").transform.FindChild("MoreOpen").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.FindChild("MoreOpen").transform.FindChild("Text").GetComponent<Text>().text = string.Concat(Summon_Manager.cardPack.ToString(), " 개 남음");
                        GameObject.Find("Canvas").transform.FindChild("AllOpen").gameObject.SetActive(true);
                    }
                    else
                    {
                        GameObject.Find("Canvas").transform.FindChild("Exit").gameObject.SetActive(true);
                    }
                }
                else // 더 개봉할게 없으면
                {
                    GameObject.Find("Canvas").transform.FindChild("Exit").gameObject.SetActive(true);
                }
                Summon_Manager.cardClickTry = 0; // 현재 씬에서 카드 클릭한수 초기화
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
