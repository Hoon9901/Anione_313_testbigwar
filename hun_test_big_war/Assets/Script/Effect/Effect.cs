using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {
    public float speed;
    public float startx;
    public float range;
    public int id;
    public string tagName;
    public int minDamage, maxDamage;
    private List<GameObject> damageList;

	// Use this for initialization
	void Awake () {
        startx = gameObject.transform.position.x;

        damageList = new List<GameObject>();
        SpriteRenderer render = this.transform.GetComponent<SpriteRenderer>();
        switch (id)
        {
            case 0: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 2: render.flipX = (this.tag == "Enemy") ? false : true; break;
            case 9: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 11: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 12: render.flipX = (this.tag == "Enemy") ? false : true; break;
        }
    }
	// Update is called once per frame
    void Update()
    {
        if (tagName == "Enemy")
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        else if (tagName == "Hero")
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (gameObject.transform.position.x - startx > range)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    void OnDamageObject()
    {
        List<GameObject> destroyList = new List<GameObject>();
        foreach (GameObject temp in damageList)
        {
            if (temp.name == "HeroTowel" || temp.name == "EnemyTowel")
            {
                if (temp.transform.GetComponent<Turret>().SetDamage(getDamage()))
                {
                    //게임 종료
           
                }
            }
            else
            {
                Character character = temp.transform.parent.GetComponent<Character>();
                int damage = getDamage();
                character.hp -= damage;
                character.setDamageText(damage);
                if (character.hp <= 0)
                {
                    destroyList.Add(temp);
                }
            }
        }
        damageList.Clear();
        foreach (GameObject temp in destroyList)
        {
            GameObject.Destroy(temp.transform.parent.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if((tagName == "Hero" && coll.tag == "Enemy") ||
            (tagName == "Enemy" && coll.tag == "Hero"))
        {
            if (coll.gameObject.name == "CrushRange" || coll.name == "HeroTowel" || coll.name == "EnemyTowel")
            {
                damageList.Add(coll.gameObject);
                switch (id)
                {
                    case 0:
                        OnDamageObject();
                        Destroy(this.gameObject); 
                        break;
                    case 9:
                        OnDamageObject();
                        Destroy(this.gameObject);
                        break;
                    case 12:
                        Animator animator = transform.GetComponent<Animator>();
                        animator.SetBool("Attack", true);
                        break;
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if ((tagName == "Hero" && coll.tag == "Enemy") ||
            (tagName == "Enemy" && coll.tag == "Hero"))
        {
            if (coll.gameObject.name == "CrushRange" || coll.name == "HeroTowel" || coll.name == "EnemyTowel")
            {
                if (damageList.Count <= 0) return;
                damageList.Remove(coll.gameObject);
            }
        }
    }

    public void onDestroy()
    {
        Destroy(this.gameObject);
    }

    public int getDamage()
    {
        System.Random rand = new System.Random();

        if (rand.Next(0, 10) >= 3)
        {
            return rand.Next((maxDamage + minDamage) / 2, maxDamage);
        }
        return rand.Next(minDamage, (maxDamage + minDamage) / 2);
    }
}
