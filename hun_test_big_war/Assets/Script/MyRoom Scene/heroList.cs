using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heroList : MonoBehaviour {
    public List<GameObject> obj_heroList = new List<GameObject>();
    public int heroCount;
    void Awake()
    {
        GameObject[] obj = new GameObject[heroCount];
        int[] unit_count = new int[heroCount];

        for (int i = 0; i < heroCount; i++)
        {
            obj[i] = GameObject.Find("hero " + i.ToString());
            obj_heroList.Add(obj[i]);
            obj_heroList[i].transform.FindChild("Count").GetComponent<Text>().text = "0";
            unit_count[i] = 0;
        }

        for (int i = 0; i < MyInfo_db.instance.cardUnit.Count; i++)
        {
            int temp = MyInfo_db.instance.cardUnit[i];
            switch (temp)
            {
                case (int)object_id.징징이:
                    unit_count[temp] += 1;
                    obj_heroList[(int)object_id.징징이].transform.FindChild("Count").GetComponent<Text>().text = unit_count[temp].ToString();
                    break;
                case (int)object_id.선인장:
                    unit_count[temp] += 1;
                    obj_heroList[(int)object_id.선인장].transform.FindChild("Count").GetComponent<Text>().text = unit_count[temp].ToString();
                    break;
                case (int)object_id.핑크빈:
                    unit_count[temp] += 1;
                    obj_heroList[(int)object_id.핑크빈].transform.FindChild("Count").GetComponent<Text>().text = unit_count[temp].ToString();
                    break;
                case (int)object_id.내면:
                    unit_count[temp] += 1;
                    obj_heroList[(int)object_id.내면].transform.FindChild("Count").GetComponent<Text>().text = unit_count[temp].ToString();
                    break;
            }
        }


        // cODE
        


    }
}
