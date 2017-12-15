using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_Btn_Click : MonoBehaviour {
    public GameObject sprite;
    void OnMouseDown()
    {
        Summon_Val.SpriteCount--;
        Destroy(sprite);
    }
	
}
