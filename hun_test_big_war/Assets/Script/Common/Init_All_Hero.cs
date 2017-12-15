using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_All_Hero : MonoBehaviour {
    public static Init_All_Hero instance = null; // Singleton Obj
    public List<GameObject> gameobject;
    public List<HeroInfo> heroInfo;
	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
	}

    void InitGame()
    {
        heroInfo = new List<HeroInfo>();
        for (int i = 0; i < gameobject.Count; i++)
        {
            Character temp = gameobject[i].GetComponent<Character>();
            heroInfo.Add(new HeroInfo(temp.id, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}