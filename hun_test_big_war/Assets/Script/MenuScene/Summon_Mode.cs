using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summon_Mode : MonoBehaviour {
    public GameObject summonModeUI;
    public GameObject Canvas;
    public GameObject NoticeText;
    public GameObject EditText;
    public GameObject SummonPanel; // Test

    // Sprite 목록 //
    public GameObject[] sprite;

    private GameObject Fade;

    public bool bIsClicked = false; // 소환 버튼이 클릭됬는가

    public bool isFadeIn = false;  // 현재 애니메이션 중인가
    public bool isFadeOut = false;

    public float fadenimTime = 2f; //  Fade 애니메이션 재생시간

    private float start;
    private float end;
    private float time = 0f;

	// Use this for initialization
	void Awake () {
        Fade = GameObject.Find("SpriteBackFade");
        Fade.SetActive(false);     
        summonModeUI.SetActive(false);
        NoticeText.SetActive(false);
        SummonPanel.SetActive(false);
    }

    public void ClickEditMode()
    {
        if (isFadeIn || isFadeOut)
            return;

        bIsClicked = !bIsClicked;
        Summon_Val.bEditMode = bIsClicked;
        summonModeUI.SetActive(bIsClicked);
        Canvas.SetActive(!bIsClicked);

        if (Summon_Val.bEditMode) // 스프라이트 편집 모드일때
        {
            Fade.SetActive(true);
            EditText.SetActive(true);
            EditText.GetComponentInChildren<Text>().text = "편집 모드";
            // 백그라운드 애니메이션 정지
            GameObject.Find("BackGround").gameObject.GetComponentInChildren<Animator>().StartPlayback();
        }
        if (!Summon_Val.bEditMode) // 편집모드 벗어날시
        {   // 백그라운드 애니메이션 실행
            Fade.SetActive(false);
            GameObject.Find("BackGround").gameObject.GetComponentInChildren<Animator>().StopPlayback(); 

            if (Summon_Val.bMoveMode) // 근데 이동모드는 true됨
            {
                EditText.GetComponentInChildren<Text>().text = "편집 모드";
                Summon_Val.bMoveMode = false;
                StartFadeOut();
            }
            if (Summon_Val.bSummonMode)
            {
                EditText.GetComponentInChildren<Text>().text = "편집 모드";
                Summon_Val.bSummonMode = false; 
                SummonPanel.SetActive(false);
                StartFadeOut();
            }
        }
    }

    public void ClickMoveMode() // 이동 모드
    {
        if (isFadeIn || isFadeOut) // 재생중이라면 중복 재생되지 않도록 리턴 처리.
            return;

        Summon_Val.bMoveMode = !Summon_Val.bMoveMode;
        if (Summon_Val.bMoveMode || Summon_Val.bSummonMode)
        {
            Summon_Val.bSummonMode = false;
            SummonPanel.SetActive(false);

            EditText.GetComponentInChildren<Text>().text = "이동 모드";
            NoticeText.GetComponentInChildren<Text>().text = "이동할 몬스터를 터치해주세요";

            NoticeText.SetActive(true);
            StartFadeIn();
        }
        else if (!Summon_Val.bMoveMode)
        {
            EditText.GetComponentInChildren<Text>().text = "편집 모드";
            StartFadeOut();
        }
    }

    public void ClickSummonMove() // 소환 모드
    {
        if (isFadeIn || isFadeOut) // 재생중이라면 중복 재생되지 않도록 리턴 처리.
            return;

        Summon_Val.bSummonMode = !Summon_Val.bSummonMode;
        if (Summon_Val.bSummonMode || Summon_Val.bMoveMode) // 소환 모드 작업하시오
        {
            Summon_Val.bMoveMode = false;
            SummonPanel.SetActive(true);

            // SummonPanel 에대한 작업
            SummonPanel.transform.FindChild("Button 0").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[0].name;
            SummonPanel.transform.FindChild("Button 1").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[1].name;
            SummonPanel.transform.FindChild("Button 2").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[2].name;
            SummonPanel.transform.FindChild("Button 3").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[3].name;
            SummonPanel.transform.FindChild("Button 4").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[4].name;
            SummonPanel.transform.FindChild("Button 5").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[5].name;
            SummonPanel.transform.FindChild("Button 6").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[6].name;
            SummonPanel.transform.FindChild("Button 7").transform.FindChild("spriteName").GetComponentInChildren<Text>().text = sprite[7].name;
            //
            EditText.GetComponentInChildren<Text>().text = "소환 모드";
            NoticeText.GetComponentInChildren<Text>().text = "소환할 몬스터를 터치해주세요";

            NoticeText.SetActive(true);
            StartFadeIn();
        }
        else if (!Summon_Val.bSummonMode)
        {
            SummonPanel.SetActive(false);
            EditText.GetComponentInChildren<Text>().text = "편집 모드";
            StartFadeOut();
        }
    }

    int Check_Summon_Count()
    {
        if (Summon_Val.SpriteCount == 3)
        {
            StartFadeOut();
            return 1;
        }
        if (Summon_Val.SpriteCount >= 7)
        {
            if (isFadeIn || isFadeOut) // 재생중이라면 중복 재생되지 않도록 리턴 처리.
                return 2;

            Summon_Val.SpriteCount = 7;
            NoticeText.GetComponentInChildren<Text>().text = "최대 8마리 소환가능합니다";
            NoticeText.SetActive(true);
            StartFadeIn();
            StartCoroutine(time_call_FadeOut());
            return 2;
        }
        return 0;
    }

    IEnumerator time_call_FadeOut()
    {
        yield return new WaitForSeconds(1.5f);
        StartFadeOut();
        StopCoroutine(time_call_FadeOut());
    }

    // Test///////////////////////////////
    public void SummonSprite0()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[0].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[0].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[0]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[0]);
        }
    }

    public void SummonSprite1()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[1].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[1].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[1]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[1]);
        }
    }

    public void SummonSprite2()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[2].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[2].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[2]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[2]);
        }
    }
    public void SummonSprite3()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[3].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[3].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[3]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[3]);
        }
    }
    public void SummonSprite4()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[4].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[4].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[4]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[4]);
        }
    }
    public void SummonSprite5()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[5].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[5].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[5]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[5]);
        }
    }
    public void SummonSprite6()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[6].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[6].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[6]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[6]);
        }
    }
    public void SummonSprite7()
    {
        if (Check_Summon_Count() != 2)
        {
            Summon_Val.SpriteCount += 1;
            sprite[7].transform.position = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
            sprite[7].GetComponent<Sprite_Click>().SpriteNumber = Summon_Val.SpriteCount;
            Debug.Log("sprite[7]의 아이디는 " + Summon_Val.SpriteCount);
            Instantiate(sprite[7]);
        }
    }

    //////////////////////////////////////
    ///////////////////////////////////// 이 아래는 FadeIn or FadeOut 에 관환 부분. ///////////////////////////////////////////////////
    public void StartFadeIn()
    {
        if (isFadeIn || isFadeOut) // 재생중이라면 중복 재생되지 않도록 리턴 처리.
            return;

        start = 0f;
        end = 1f;
        StartCoroutine(PlayFadeIn());
    }

    public void StartFadeOut()
    {
        if (isFadeIn || isFadeOut) // 재생중이라면 중복 재생되지 않도록 리턴 처리.
            return;

        start = 1f;
        end = 0f;
        StartCoroutine(PlayFadeOut());
    }

    IEnumerator PlayFadeIn()
    {
        Debug.Log("FadeIn 호출");
        // 페이드인 진행중
        isFadeIn = true;
        // Text 컴포넌트의 색상 값 읽어오기.
        Color color = NoticeText.GetComponentInChildren<Text>().color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            // 경과 시간 계산
            time += Time.deltaTime / fadenimTime;

            // 알파 값 계산
            color.a = Mathf.Lerp(start, end, time);
            //
            NoticeText.GetComponentInChildren<Text>().color = color;

            yield return null;
        }
        // 애니메이션 재생 완료
        isFadeIn = false;
    }
    IEnumerator PlayFadeOut()
    {
        Debug.Log("FadeOut 호출");
        // 페이드인 진행중
        isFadeOut = true;
        // Text 컴포넌트의 색상 값 읽어오기.
        Color color = NoticeText.GetComponentInChildren<Text>().color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a > 0f)
        {
            // 경과 시간 계산
            time += Time.deltaTime / fadenimTime;

            // 알파 값 계산
            color.a = Mathf.Lerp(start, end, time);
            //
            NoticeText.GetComponentInChildren<Text>().color = color;

            yield return null;
        }
        // 애니메이션 재생 완료
        isFadeOut = false;
        NoticeText.SetActive(false);
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	
	// Update is called once per frame
	void Update () {
		
	}
}
