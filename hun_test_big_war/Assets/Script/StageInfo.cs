using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour {
    public Transform heroLoc;
    public Transform enemyLoc;
    public Transform heroMineSpawnLoc;
    public Transform enemyMineSpawnLoc;
    public Transform heroMineMiningLoc;
    public Transform enemyMineMiningLoc;
    public static List<Character> heroSetting;
    public static List<Character> enemySetting;
    public static List<HeroInfo> enemyID;
    public static FontType enemyFont;
    public static int enemyMinerID;
    public static int enemyMinerPrice;
    public static int[] g_Money;
    public static float stage_Y;
    public static int stage;

	// Use this for initialization
	void Start () {
        g_Money = new int[2];
        g_Money[0] = 10000; g_Money[1] = 1000;
        enemySetting = new List<Character>();
        SettingFunction();
        initStage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SettingFunction()
    {
        heroSetting = new List<Character>();
        enemySetting = new List<Character>();
        for (int i = 0; i < 4; i++)
        {
            Character temp = GameObject.Find("Main Camera").GetComponent<HeroButton>().gameObject[MyInfo.settingHero[i].id].GetComponent<Character>();
            temp.onInitByHeroInfo(MyInfo.settingHero[i]);
            heroSetting.Add(temp);
            temp = GameObject.Find("Main Camera").GetComponent<HeroButton>().gameObject[enemyID[i].id].GetComponent<Character>();
            temp.onInitByHeroInfo(enemyID[i]);
            enemySetting.Add(temp);
        }
    }
    public void initStage()
    {
        Character temp = new Character();
        switch (stage)
        {
            case 1:
                enemyMinerID = 0;
                enemyMinerPrice = GameObject.Find("Main Camera").GetComponent<MinerSpawn>().miner[enemyMinerID].GetComponent<Miner>().price;
                enemyFont = FontType.IrinaBand;
                stage_Y = -3.3f;
                FloatingTextController.Initialize();
                break;
            case 2:
                enemyMinerID = 0;
                enemyMinerPrice = GameObject.Find("Main Camera").GetComponent<MinerSpawn>().miner[enemyMinerID].GetComponent<Miner>().price;
                enemyFont = FontType.IrinaBand;
                stage_Y = -3.3f;
                FloatingTextController.Initialize();
                break;
        }
    }
}
