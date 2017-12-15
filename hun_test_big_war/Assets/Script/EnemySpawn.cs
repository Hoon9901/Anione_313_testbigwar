using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawn : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
        StartCoroutine(Spawn(8.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawn(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            System.Random r = new System.Random();
            int tempR = 0;

            if (StageInfo.g_Money[1] <= 500)
            {
                if (StageInfo.enemyMinerPrice <= StageInfo.g_Money[1])
                {
                    GameObject.Find("Main Camera").GetComponent<MinerSpawn>().spawnEnemyMiner();
                }
            }
            else
            {
                while (true)
                {
                    tempR = r.Next(0, 4);
                    Debug.Log("tempR : " + tempR);
                    if (tempR != 4)
                    {
                        if (StageInfo.enemySetting[tempR].price <= (StageInfo.g_Money[1] - StageInfo.enemyMinerPrice))
                        {
                            StageInfo.g_Money[1] -= StageInfo.enemySetting[tempR].price;
                            spawnEnemy(tempR);
                            break;
                        }
                    }
                    else if (tempR == 4)
                    {
                        if (StageInfo.enemyMinerPrice <= StageInfo.g_Money[1])
                        {
                            GameObject.Find("Main Camera").GetComponent<MinerSpawn>().spawnEnemyMiner();
                            break;
                        }
                    }
                }
            }
        }
    }

    public void spawnEnemy(int loc)
    {
        Character t = StageInfo.enemySetting[loc];
        int heroID = t.id;
        Debug.Log("ID : " + heroID);
        GameObject obj = GameObject.Find("Main Camera").GetComponent<HeroButton>().gameObject[heroID];

        Vector2 temp = new Vector2(0, 0);
        obj.tag = "Enemy";
        obj.transform.GetChild(0).tag = "Enemy";
        //if (obj.tag == "Enemy") temp = GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyLoc.position;
        temp = GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyLoc.position;
        System.Random r = new System.Random();
        BoxCollider2D boxCollider = obj.GetComponent<BoxCollider2D>();
        switch (heroID)
        {
            case 0: temp.y += 1.1f; break;
            case 1: temp.y -= 0.3f; break;
            case 2: temp.y += 0.5f; break;
            case 3: temp.y += 1.2f; break;
        }
        temp.y -= (float)r.NextDouble() / 5;
        Instantiate(obj, temp, GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyLoc.rotation);
        t.onInitIndex();
        t.Apply(MyInfo.settingHero[loc].forceIndex);
        obj.SetActive(true);
    }
}
