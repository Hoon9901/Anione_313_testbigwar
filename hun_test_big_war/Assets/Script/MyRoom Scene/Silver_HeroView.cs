using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
public class Silver_HeroView : MonoBehaviour {
    public List<GameObject> g_obj_Heros = new List<GameObject>();
    public int HeroCount;
    public int[] unit_count;
    public Vector2 clickbeganPos;
    void Awake()
    {
        GameObject[] obj = new GameObject[HeroCount];
        unit_count = new int[HeroCount]; // 각각 스프라이트의 갯수 (ID1번의 갯수 10개)

        for (int i = 0; i < HeroCount; i++)
        {
            // g_obj_Heros 배열에 해당 갑 초기화
            obj[i] = transform.FindChild("Unit " + i.ToString()).gameObject;
            g_obj_Heros.Add(obj[i]);
            // 알파값 설정
            Color colortemp = g_obj_Heros[i].GetComponentInChildren<Image>().color;
            g_obj_Heros[i].GetComponentInChildren<Image>().color = new Color(colortemp.r, colortemp.g, colortemp.b, 0.4f);
            // 유닛 갯수 초기화
            unit_count[i] = 0;
        }

        if (MyInfo_db.instance != null || MyInfo_db.instance.cardUnit.Count > 0) 
        {
            for (int i = 0; i < MyInfo_db.instance.cardUnit.Count; i++)
            {
                int temp = MyInfo_db.instance.cardUnit[i];
                switch (temp) // 아이디에 따른 유닛 갯수 초기화
                {
                    case (int)object_id.선인장:
                        unit_count[0] += 1;
                        if (unit_count[0] == 1)
                        {
                            Color color = g_obj_Heros[0].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[0].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.나루토:
                        unit_count[1] += 1;
                        if (unit_count[1] == 1)
                        {
                            Color color = g_obj_Heros[1].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[1].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.징징이:
                        unit_count[2] += 1;                        
                        if (unit_count[2] == 1)
                        {
                            Color color = g_obj_Heros[2].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[2].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.나미:
                        unit_count[3] += 1;
                        if (unit_count[3] == 1)
                        {
                            Color color = g_obj_Heros[3].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[3].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.키리토:
                        unit_count[4] += 1;
                        if (unit_count[4] == 1)
                        {
                            Color color = g_obj_Heros[4].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[4].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.엘:
                        unit_count[5] += 1;
                        if (unit_count[5] == 1)
                        {
                            Color color = g_obj_Heros[5].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[5].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                }
            }
        }
        // Code

        StartCoroutine(_Updata_());
    }

    IEnumerator _Updata_()
    {
        float ftime = 0f;
        while (MyRoom_Manager.currentView.Equals((int)MyRoom_Manager.view_id.Silver))
        {
            if (Input.GetMouseButton(0))
            {
                // 누르는 시간체크
                ftime += Time.deltaTime;
                int sec = (int)ftime % 60;
                if(sec > 1) // 1초 초과시
                {
                    ftime = 0;
                    sec = 0;
                    Vector2 clickpos = (Vector2)Input.mousePosition;
                    clickbeganPos = Camera.main.ScreenToWorldPoint(clickpos);

                    RaycastHit2D hit = Physics2D.Raycast(clickbeganPos, Vector2.zero);
                    if (hit.collider != null)
                    {
                        if (hit.transform.gameObject.name.Contains("Unit"))
                        {
                            string name = hit.transform.gameObject.name;
                            string temp = Regex.Replace(name, @"\D", "");
                            Debug.Log(name + "의 갯수 " + MyInfo_db.instance.cardUnit_count[int.Parse(temp)]);
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
