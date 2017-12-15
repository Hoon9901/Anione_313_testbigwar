using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void setStage(int stage)
    {
        StageInfo.stage = stage;
        SceneManager.LoadScene("PickScene");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
