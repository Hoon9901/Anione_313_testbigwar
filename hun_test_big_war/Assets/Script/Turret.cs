using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Turret : MonoBehaviour {
    private int HP;
    public int MaxHp;
	// Use this for initialization
	void Start () {
        HP = MaxHp;
        SettingProgressBar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SettingProgressBar()
    {
        float progress = (float)HP / (float)MaxHp;
        transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = progress;
    }
    public bool SetDamage(int damage)
    {
        HP -= damage;
        setDamageText(damage);
        if (HP < 0) { 
            HP = 0;
            if (StageInfo.stage < 3)
            {
                SceneManager.LoadScene("");
                for (int i = 0; i < 4; i++) GameObject.Find("Stage" + (StageInfo.stage + 1)).transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        SettingProgressBar();

        if (HP == 0)
        {
            return true;
        }
        return false;
    }

    public void setDamageText(int damage)
    {
        if (this.tag == "Enemy")
            FloatingTextController.CreateFloatingText(damage.ToString(), transform);
        else if (this.tag == "Hero")
            FloatingTextController.CreateFloatingTextEnemy(damage.ToString(), transform);
    }
}
