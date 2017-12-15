using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : MonoBehaviour {
    public GameObject Effect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEffect(Transform transform, string tag)
    {
        Effect.tag = tag;
        float range = Effect.GetComponent<Effect>().range;
        Effect.GetComponent<Effect>().tagName = tag;
        range = tag == "Enemy" ? -range : range;
        Effect.GetComponent<Effect>().range = range;
        Vector3 pos = new Vector3(transform.position.x, StageInfo.stage_Y);
        Instantiate(Effect, pos, transform.rotation);
    }
}
