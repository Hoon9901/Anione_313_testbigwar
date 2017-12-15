using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_HeroView : MonoBehaviour {
    public List<GameObject> g_obj_Heros = new List<GameObject>();
    public int HeroCount;
    public int[] unit_count;
    void Awake()
    {
        GameObject[] obj = new GameObject[HeroCount];
        unit_count = new int[HeroCount];

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
                    case (int)object_id.핑크빈:
                        unit_count[0] += 1;
                        if (unit_count[0] == 1)
                        {
                            Color color = g_obj_Heros[0].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[0].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.사스케:
                        unit_count[1] += 1;
                        if (unit_count[1] == 1)
                        {
                            Color color = g_obj_Heros[1].GetComponentInChildren<Image>().color;
                            color.a = 1;    
                            g_obj_Heros[1].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                    case (int)object_id.루피:
                        unit_count[2] += 1;
                        if (unit_count[2] == 1)
                        {
                            Color color = g_obj_Heros[2].GetComponentInChildren<Image>().color;
                            color.a = 1;
                            g_obj_Heros[2].GetComponentInChildren<Image>().color = color;
                        }
                        break;
                }
            }
        }
        // Code
    }
}
