using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float _fCameraMoveMinX; //최소 이동 가능한 X값
    public float _fCameraMoveMaxX;//최대 이동 가능한 X값
    public float cameraSpeed = 0.1f;
    public bool isMove;
    private bool SettingBtnIsShow;
    private float InitPos_y;
    // Touch
    private Vector2 touchedPos;
    public Vector2 nowPos, prePos; 
    public Vector2 movePos;
    public int cameraSensitivity = 10;

    // Use this for initialization
    void Awake()
    {
        InitPos_y = transform.position.y;
        isMove = true;

        StartCoroutine(_CameraMove_());
    }

    void MoveLimit()
    {
        Vector2 temp;
        temp.x = Mathf.Clamp(transform.position.x, _fCameraMoveMinX, _fCameraMoveMaxX);
        temp.y = InitPos_y;
        transform.position = new Vector3(temp.x , temp.y, -10);
    }

    IEnumerator _CameraMove_()
    {
        while (true)
        {
            if (isMove && !Summon_Val.bSpriteClicked)
            {
#if (UNITY_EDITOR) // 유니티 에디터 에서 구동되는 소스
                if (Input.GetMouseButton(0))
                {
                    if (Input.GetAxis("Mouse X") < 0)
                    {
                        transform.Translate(cameraSpeed, 0, 0);
                        MoveLimit();
                    }
                }
                if (Input.GetMouseButton(0))
                {
                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        transform.Translate(-cameraSpeed, 0, 0);
                        MoveLimit();
                    }
                }
#elif UNITY_ANDROID // 안드로이드 플랫폼에서 구동되는 소스
                if (Input.touchCount == 1)
                {
                    UnityEngine.Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        prePos = touch.position - touch.deltaPosition;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        nowPos = touch.position - touch.deltaPosition;
                        movePos = (Vector2)(prePos - nowPos) * 0.1f;

                        transform.Translate(movePos / cameraSensitivity);

                        MoveLimit();

                        prePos = touch.position - touch.deltaPosition;
                    }
                }
#endif
            }
            yield return null;
        }
    }
}
