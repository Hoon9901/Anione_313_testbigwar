using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SpriteMove는 스프라이트의 움직이는 함수와 애니메이션에 관한 클래스

public class SpriteMove : MonoBehaviour {
    public float speed = 1.0f; // 속도
    public bool Fly = false;
    public float posGround_y = 0;
    // 랜덤 변수 범위 (퍼스트, 라스트)
    public Vector2 firstPos;
    public Vector2 lastPos;
    //
    private Vector2 posTarget; // 도착 지점
    private SpriteRenderer renderer; // 렌더러 변수
    private Animator animator;
    private bool bSwitch = false;
	// Use this for initialization
	void Start () {
	}

    void OnEnable()
    {
        Invoke("resetPos", 2.0f);

        if (Fly)
        {
            posTarget.Set(Random.Range(firstPos.x, lastPos.x), Random.Range(firstPos.y, lastPos.y));
        }
        else
        {
            posTarget.x = Random.Range(firstPos.x, lastPos.x);
            transform.position.Set(transform.position.x, posGround_y, 0);
        }
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        animator = gameObject.GetComponentInChildren<Animator>();

        StartCoroutine(MoveSprite()); // MoveSprite Load
    }
    void OnDisable()
    {
        StopCoroutine(MoveSprite());
    }

    IEnumerator MoveSprite()
    {
        while (enabled) // 이 스프라이트의 보이기에 따라 while이 돌아감
        {
            if (!Summon_Val.bEditMode)// 편집 모드가 아닐때 움직임
            {
                animator.StopPlayback();
                if (transform.position.x > posTarget.x)
                {
                    if (this.tag.Equals("스프라이트_렌더_반대"))
                    {
                        renderer.flipX = false;
                    }
                    else
                    {
                        renderer.flipX = true;
                    }
                }
                else
                {
                    if (this.tag.Equals("스프라이트_렌더_반대"))
                    {
                        renderer.flipX = true;
                    }
                    else
                    {
                        renderer.flipX = false;
                    }
                }
                if (Fly)
                {
                    transform.position = Vector2.MoveTowards(transform.position, posTarget, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, posTarget.x, speed * Time.deltaTime), posGround_y);
                   // Debug.Log("좌표 : " + transform.position.x +"  "+transform.position.y);
                }
            }
            else if (Summon_Val.bEditMode) // 편집 모드일때 정지함
            {
                animator.StartPlayback();
            }
            yield return null;
        }
    }

    void resetPos()
    {
        if (!Summon_Val.bEditMode )
        {
            if (Fly)
            {
                posTarget.Set(Random.Range(firstPos.x, lastPos.x), Random.Range(firstPos.y, lastPos.y));
            }
            else
            {
                posTarget.x = Random.Range(firstPos.x, lastPos.x);
            }
        }
        Invoke("resetPos", 2.0f);
    }
}
