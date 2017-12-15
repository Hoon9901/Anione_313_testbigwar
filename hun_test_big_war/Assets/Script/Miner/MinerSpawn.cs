using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerSpawn : MonoBehaviour {
    public List<GameObject> miner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void spawnHeroMiner()
    {
        GameObject obj = miner[MyInfo.minerID];
        Vector2 temp = new Vector2(0, 0);
        obj.tag = "Hero";
        Miner mine = obj.GetComponent<Miner>();
        temp = GameObject.Find("Main Camera").GetComponent<StageInfo>().heroMineSpawnLoc.position;
        System.Random r = new System.Random();
        switch (MyInfo.minerID)
        {
            case 0: temp.y += 0.2f; break;
        }
        Instantiate(obj, temp, GameObject.Find("Main Camera").GetComponent<StageInfo>().heroMineSpawnLoc.rotation);
        obj.SetActive(true);
    }
    public void spawnEnemyMiner()
    {
        GameObject obj = miner[StageInfo.enemyMinerID];
        Vector2 temp = new Vector2(0, 0);
        obj.tag = "Enemy";
        Miner mine = obj.GetComponent<Miner>();
        temp = GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyMineSpawnLoc.position;
        System.Random r = new System.Random();
        switch (StageInfo.enemyMinerID)
        {
            case 0: temp.y += 0.2f; break;
        }
        Instantiate(obj, temp, GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyMineSpawnLoc.rotation);
        obj.SetActive(true);
    }
}
