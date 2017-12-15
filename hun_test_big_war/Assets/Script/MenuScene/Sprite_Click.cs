using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Click : MonoBehaviour {
    public int SpriteNumber = -1;
    public bool OnDestroyBtnShow = false;

    Coroutine co_DestroyBtnShow;
    Coroutine co_MoveMode_Clicked_Sprite;
    // Use this for initialization
    void Awake()
    {
        transform.FindChild("Destroy_btn").gameObject.SetActive(false);
	}

    void OnEnable()
    {
        Debug.Log(SpriteNumber + " 번 스프라이트 OnEnable");
    }

    void OnDisable()
    {
        Debug.Log(SpriteNumber + " 번 스프라이트 OnDisable");
    }

    IEnumerator DestroyBtnShow()
    {
        while (enabled)  // Normal State
        {
            Debug.Log("코루틴 함수 내부에서 Debug.Log를 출력합니다");
            if (!Summon_Val.bSummonMode) // 소환 모드가 아닐때(노말 상태)
            {
                OnDestroyBtnShow = false;
                this.transform.FindChild("Destroy_btn").gameObject.SetActive(false);
                StopCoroutine(co_DestroyBtnShow);
            }
            yield return null;
        }
    }

    IEnumerator MoveMode_Clicked_Sprite() // 이동 모드에서 스프라이트 클릭할때
    {
        while (enabled)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0)) 
            {
                Debug.Log("클릭됨");
                Summon_Val.bSpriteClicked = true;
                transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            } if (Input.GetMouseButtonUp(0))
            {
                Summon_Val.bSpriteClicked = false;
                StopCoroutine(co_MoveMode_Clicked_Sprite);
            }
            yield return null;
#endif
#if UNITY_ANDROID
            if (Input.touchCount == 1)
            {
                UnityEngine.Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Summon_Val.bSpriteClicked = true;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Summon_Val.bSpriteClicked = false;
                    StopCoroutine(co_MoveMode_Clicked_Sprite);
                }
                yield return null;
            }
#endif
        }
    }

    void OnMouseDown()
    {
        if (Summon_Val.bEditMode)
        {
            Summon_Val.SpriteID = SpriteNumber;
            Debug.Log("선택한 스프라이트 : " + Summon_Val.SpriteID);
            if (Summon_Val.bMoveMode) // 이동 모드일때 클릭시 터치나 마우스 위치에 스프라이트 이동
            {
                co_MoveMode_Clicked_Sprite = StartCoroutine(MoveMode_Clicked_Sprite());
            }
            if (Summon_Val.bSummonMode)
            {
                Debug.Log(this.transform.FindChild("Destroy_btn").gameObject.activeSelf);
                if (!OnDestroyBtnShow)
                {
                    co_DestroyBtnShow = StartCoroutine(DestroyBtnShow());

                    OnDestroyBtnShow = true;
                    this.transform.FindChild("Destroy_btn").gameObject.SetActive(true);
                }
                else if (OnDestroyBtnShow)
                {
                    OnDestroyBtnShow = false;
                    this.transform.FindChild("Destroy_btn").gameObject.SetActive(false);
                }
            }
            if (!Summon_Val.bMoveMode && !Summon_Val.bSummonMode) // 편집 모드일때만
            {
            }
        }
    }
}
