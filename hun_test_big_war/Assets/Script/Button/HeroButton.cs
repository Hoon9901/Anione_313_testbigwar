using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HeroButton : MonoBehaviour 
{
    public List<GameObject> gameObject;
    
    void Start()
    {
    }
	// Use this for initialization
    public void spawnHero(int loc)
    {        
        int heroID = MyInfo.settingHero[loc].id;
        GameObject obj = gameObject[heroID];
        Character t = StageInfo.heroSetting[loc];

        Vector2 temp = new Vector2(0, 0);
        obj.tag = "Hero";
        obj.transform.GetChild(0).tag = "Hero";
        //if (obj.tag == "Enemy") temp = GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyLoc.position;
        temp = GameObject.Find("Main Camera").GetComponent<StageInfo>().heroLoc.position;
        System.Random r = new System.Random();
        BoxCollider2D boxCollider = obj.GetComponent<BoxCollider2D>();
        switch (heroID)
        {
            case 0: temp.y += 1.1f; break;
            case 1: temp.y -= 0.3f; break;
            case 2: temp.y += 0.5f; break;
            case 3: temp.y += 1.2f; break;
            case 4: temp.y += 0.6f; break;
            case 5: temp.y += 0.5f; break;
        }
        temp.y -= (float)r.NextDouble()/5;
        Instantiate(obj, temp, GameObject.Find("Main Camera").GetComponent<StageInfo>().heroLoc.rotation);
        t.Apply(MyInfo.settingHero[loc].forceIndex);
        obj.SetActive(true);
    }
}
