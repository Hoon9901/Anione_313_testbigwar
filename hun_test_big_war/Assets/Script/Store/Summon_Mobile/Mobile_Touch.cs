using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Mobile_Touch : MonoBehaviour {
    // Touch 변수
    private UnityEngine.Touch tempTocuhs;
    private Vector2 touchBeganPos;
    private bool touchOn;
    // 클릭 변수
    public Vector2 clickbeganPos;
    // 카드 옵젝 변수
    public GameObject Cards;
    // 게임 변수
    public bool IsMove = false;
    public bool moveR = false;
    public bool moveL = false;
    public float target_rX = -4f;
    public float traget_lX = 0;
    //
    public int[] cardScale;
    public int selCard = 0; // 화면 중앙에 오는 카드의 넘버

	// Use this for initialization
    void Awake()
    {
        cardScale = new int[] { 0, 0, 0, 0, 0 };

        StartCoroutine(_InputProcess_());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        selCard = int.Parse(Regex.Replace(col.name ,  @"\D", ""));
        Summon_Manager.cardSel = selCard;

        if (selCard == 0)
        {
            cardScale[selCard] = 2;
            cardScale[selCard + 1] = 1;
            cardScale[selCard + 2] = 0;
        }
        if (selCard == 1)
        {
            cardScale[selCard] = 2;
            cardScale[selCard + 1] = 1;
            cardScale[selCard + 2] = 0;

            cardScale[selCard - 1] = 1;
        }
        if (selCard == 2)
        {
            cardScale[selCard] = 2;
            cardScale[selCard + 1] = 1;
            cardScale[selCard + 2] = 0;

            cardScale[selCard - 1] = 1;
            cardScale[selCard - 2] = 0;
        }
        if (selCard == 3)
        {
            cardScale[selCard] = 2;
            cardScale[selCard + 1] = 1;
            
            cardScale[selCard - 1] = 1;
            cardScale[selCard - 2] = 0;
        }
        if (selCard == 4)
        {
            cardScale[selCard] = 2;
            cardScale[selCard - 1] = 1;
            cardScale[selCard - 2] = 0;
        }

        for (int i = 0; i < 5; i++)
        {
            if(cardScale[i] == 2)
            {
                col.gameObject.transform.localScale = new Vector2(Mathf.Lerp(0.7f, 0.8f, Time.timeScale), Mathf.Lerp(0.7f, 0.8f, Time.timeScale));
            }
            else if (cardScale[i] == 1)
            {
                GameObject.Find("Cards").transform.FindChild("Card "+ i).gameObject.transform.localScale = new Vector2(Mathf.Lerp(0.7f, 0.6f, Time.timeScale), Mathf.Lerp(0.7f, 0.6f, Time.timeScale));
            }
            else if (cardScale[i] == 0)
            {
                GameObject.Find("Cards").transform.FindChild("Card " + i).gameObject.transform.localScale = new Vector2(Mathf.Lerp(0.7f, 0.5f, Time.timeScale), Mathf.Lerp(0.7f, 0.5f, Time.timeScale));
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
    }

    IEnumerator _InputProcess_()
    {
        while (!Summon_Manager.bAllOpen)
        {
#if UNITY_EDITOR
            processInput();
#elif UNITY_ANDROID
        processMobileInput();
#endif
            processCommon();
            yield return null;
        }
    }
	
    void processMobileInput()
    {
        touchOn = false;
        if (Input.touches.Length > 0)
        {
            tempTocuhs = Input.GetTouch(0);
            switch (tempTocuhs.phase)
            {
                case TouchPhase.Began: // 스크린상에 터치가 되었을때
                    Debug.Log("Touch Began");
                    Vector2 touchedPos = tempTocuhs.position;
                    touchBeganPos = Camera.main.ScreenToWorldPoint(touchedPos);

                    RaycastHit2D hit = Physics2D.Raycast(clickbeganPos, Vector2.zero);
                    //if (hit.collider != null)
                    //{
                    //    if (hit.transform.gameObject.name.Equals("Card " + selCard.ToString()))
                    //        Debug.Log("카드 소환해라");
                    //}
                    break;
                case TouchPhase.Moved: // 터치후 손가란을 움직였을때
                    Vector2 currentTouchPos = Camera.main.ScreenToWorldPoint(tempTocuhs.position);
                    if (currentTouchPos.x > touchBeganPos.x) // 손가락이 오른쪽으로 이동중 (Left)
                    {
                        Debug.Log("Left");
                        if (!IsMove)
                        {
                            moveR = false;
                            moveL = true;
                        }
                    }
                    else if (currentTouchPos.x < touchBeganPos.x) // 손가락이 왼쪽으로 이동중 (right)
                    {
                        Debug.Log("Right");
                        if (!IsMove)
                        {
                            moveR = true;
                            moveL = false;
                        }
                    }
                    break;
                case TouchPhase.Stationary: // 움직이고 멈췄을때
                    break;
                case TouchPhase.Ended: // 스크린상에 손가락이 때졌을때
                    Debug.Log("Touch Ended");
                    break;
            }
        }
    }
    void processInput()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 버튼을 누르면 한번 실행
        {
            Vector2 clickpos = (Vector2)Input.mousePosition;
            clickbeganPos = Camera.main.ScreenToWorldPoint(clickpos);

            RaycastHit2D hit = Physics2D.Raycast(clickbeganPos, Vector2.zero);
            //if (hit.collider != null)
            //{
            //    if (hit.transform.gameObject.name.Equals("Card " + selCard.ToString()))
            //        Debug.Log("카드 소환해라");
            //}
        }
        if (Input.GetMouseButton(0)) // 마우스 누르고 있을때 계속 실행
        {
            Vector2 currentClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (currentClickPos.x > clickbeganPos.x) // Left
            {
                if (!IsMove)
                {
                    moveR = false;
                    moveL = true;
                }
            }
            if (currentClickPos.x < clickbeganPos.x)
            {
                if (!IsMove)
                {
                    moveR = true;
                    moveL = false;
                }
            }
        }
    }

    void processCommon()
    {
        if (moveR)
        {
            if (target_rX != -20)
            {
                if (Cards.transform.position.x > target_rX)
                {
                    Cards.transform.position += new Vector3(Time.deltaTime * -10f, 0f, 0f);
                    IsMove = true;
                    if ((int)Cards.transform.position.x == target_rX)
                    {
                        Cards.transform.position = new Vector3(target_rX, 0, 0);
                        IsMove = false;
                        target_rX = (int)Cards.transform.position.x - 4;
                        traget_lX = (int)Cards.transform.position.x + 4;
                        moveR = false;
                    }
                }
            }
        }
        else if (moveL)
        {
            if (traget_lX != 4)
            {
                if (Cards.transform.position.x < traget_lX)
                {
                    Cards.transform.position += new Vector3(Time.deltaTime * 10f, 0f, 0f);
                    IsMove = true;
                    if ((int)Cards.transform.position.x == traget_lX)
                    {
                        Cards.transform.position = new Vector3(traget_lX, 0, 0);
                        IsMove = false;
                        target_rX = (int)Cards.transform.position.x - 4;
                        traget_lX = (int)Cards.transform.position.x + 4;
                        moveL = false;
                    }
                }
            }
        }
    }

}
