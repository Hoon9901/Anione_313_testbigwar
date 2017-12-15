using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManage : MonoBehaviour {
    public GameObject g_effect;
    public float g_rage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnEffect()
    {
        Effect temp = g_effect.GetComponent<Effect>();
        temp.tagName = this.gameObject.tag;
        Vector3 tempLoc = this.transform.position;
        tempLoc.x += temp.tagName == "Hero" ? g_rage : -g_rage;
        temp.minDamage = this.GetComponent<Character>().minDamage;
        temp.maxDamage = this.GetComponent<Character>().maxDamage;
        temp.id = this.GetComponent<Character>().id;
        switch (temp.id)
        {
            case 2: tempLoc.y -= 0.5f;
                break;
            case 9: if (temp.tagName == "Hero") tempLoc.x -= 7.0f;
                else if (temp.tag == "Enemy") tempLoc.x += 7.0f;
                break;
            case 11:
                tempLoc.y += 0.5f;
                break;
        }
        Instantiate(g_effect, tempLoc, g_effect.transform.rotation);
        Debug.Log("생성");
    }
}
