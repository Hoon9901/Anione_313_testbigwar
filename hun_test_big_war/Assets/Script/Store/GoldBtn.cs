using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBtn : MonoBehaviour {
    public GameObject ScrollView;

	// Use this for initialization
    void Start()
    {
	}

    public void Click()
    {
        ScrollView.SetActive(true);
        GameObject.Find("Store Manager").GetComponent<HeroPackBtn>().ScrollView.SetActive(false);
        GameObject.Find("Store Manager").GetComponent<CrystalBtn>().ScrollView.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
