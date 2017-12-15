using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string char_name;
    public Grade_Enum grade;
    public int hp, id, price;
    public int minDamage, maxDamage;
    public int[] initIndex;
    public float[] initFloat;
    public float speed, coolTime;

    void Awake()
    {
        onInitIndex();
        //Apply(0);
        SpriteRenderer render = this.transform.GetComponent<SpriteRenderer>();
        switch (id)
        {
            case 0: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 1: render.flipX = (this.tag == "Enemy") ? false : true; break;
            case 2: render.flipX = (this.tag == "Enemy") ? false : true; break;
            case 3: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 4: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 5: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 6: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 7: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 8: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 9: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 10: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 11: render.flipX = (this.tag == "Enemy") ? true : false; break;
            case 12: render.flipX = (this.tag == "Enemy") ? false : true; break;
        }
    }
    public void onInitIndex()
    {
        initIndex = new int[3];
        initIndex[0] = hp; initIndex[1] = minDamage; initIndex[2] = maxDamage;
        initFloat = new float[2];
        initFloat[0] = speed; initFloat[1] = coolTime;
    }
    public void onInitByHeroInfo(HeroInfo heroInfo)
    {
        
    }
    public void onDamageObject()
    {
        this.transform.GetChild(0).GetComponent<PlayerManage>().onDamageObject();
    }
    public void onDamageObjects()
    {
        this.transform.GetChild(0).GetComponent<PlayerManage>().onDamageObjects();
    }
    public void onRunObject()
    {
        this.transform.GetChild(0).GetComponent<PlayerManage>().run = true;
    }
    public void onStopObject()
    {
        this.transform.GetChild(0).GetComponent<PlayerManage>().run = false;
    }
	// Use this for initialization
    public void Apply(int index)
    {
        /*
        hp = ((int)grade + 1) * initIndex[0] + index * 20;
        //attack = ((int)grade + 1) * initIndex[1] + index * 30;
        speed = ((int)grade + 1) * initFloat[0] + index * 0.2f;
        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
       // box.size = new Vector2(range, 0);
         * */
    }
    public void Apply(Grade_Enum grade, int index)
    {
        /*
        hp = ((int)grade + 1) * initIndex[0] + index * 20;
        //attack = ((int)grade + 1) * initIndex[1] + index * 30;
        speed = ((int)grade + 1) * initFloat[0] + index * 0.2f;
        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
        //box.size = new Vector2(range, 0);
         * */
        this.grade = grade;
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
    void OnTriggerEnter2D(Collider2D coll)
    {
        if ((coll.gameObject.tag == "Enemy" && gameObject.tag == "Hero") ||
            (coll.gameObject.tag == "Hero" && gameObject.tag == "Enemy"))
        {
            if (coll.gameObject.name == "CrushRange" || coll.gameObject.name == "HeroTowel" || coll.gameObject.name == "EnemyTowel")
            {
                Debug.Log("coll : " + coll.transform.parent.name + ", gameobject : " + gameObject.name);
                gameObject.transform.GetChild(0).transform.GetComponent<PlayerManage>().damageList.Add(coll.gameObject);
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {        
        if ((coll.gameObject.tag == "Enemy" && gameObject.tag == "Hero") ||
            (coll.gameObject.tag == "Hero" && gameObject.tag == "Enemy"))
        {
            if (coll.gameObject.name == "CrushRange" || coll.gameObject.name == "HeroTowel" || coll.gameObject.name == "EnemyTowel")
            {
                PlayerManage manage = this.gameObject.transform.GetChild(0).transform.GetComponent<PlayerManage>();
                if (manage.damageList.Contains(coll.gameObject)) manage.damageList.Remove(coll.gameObject);
            }
        }
    }
    public void setDamageText(int damage)
    {
        if (this.tag == "Enemy")
            FloatingTextController.CreateFloatingText(damage.ToString(), transform);
        else if (this.tag == "Hero")
            FloatingTextController.CreateFloatingTextEnemy(damage.ToString(), transform);
    }
    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
};