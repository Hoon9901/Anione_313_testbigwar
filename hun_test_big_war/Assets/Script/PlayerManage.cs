using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour {
    public List<GameObject> damageList;
    private Animator animator;
    public bool run;
    // 최초 실행 되는 함수
    void Awake()
    {
        animator = gameObject.transform.parent.GetComponent<Animator>();
        damageList = new List<GameObject>();
        run = false;
    }
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        AnimationUpdate();
        if (damageList.Count == 0)
        {
            Character temp = this.transform.parent.GetComponent<Character>();
            if (temp.id == 7)
            {
                if(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Tamama_WalkReady") ||
                    animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Tamama_Attack"))
                {
                    return;
                }
            }
            if (gameObject.tag == "Enemy")
                this.transform.parent.transform.Translate(Vector3.left * Time.deltaTime * temp.speed);
            else if (gameObject.tag == "Hero")
                this.transform.parent.transform.Translate(Vector3.right * Time.deltaTime * temp.speed);
        }
    }

    public float getDistance(Vector3 arg0, Vector3 arg1)
    {
        return Math.Abs(arg0.x - arg1.x);
    }
    public GameObject getClosestObject()
    {
        float range = 100.0f;
        if (damageList.Count <= 0) return null;
        GameObject obj = damageList[0];
        foreach (GameObject temp in damageList)
        {
            if (temp != null)
            {
                if (temp.name == "HeroTowel" || temp.name == "EnemyTowel")
                {
                    if (damageList.Count == 1)
                    {
                        obj = temp;
                        break;
                    }
                    else continue;
                }
                else if (getDistance(temp.transform.parent.transform.position, this.transform.parent.transform.position) < range)
                {
                    obj = temp;
                    range = getDistance(temp.transform.parent.transform.position, this.transform.parent.transform.position);
                }
            }
        }
        return obj;
    }
    public void onDamageObject()
    {
        if (damageList.Count <= 0) return;
        GameObject obj = getClosestObject();
        if (obj.name == "HeroTowel" || obj.name == "EnemyTowel")
        {
            int damage = this.transform.parent.GetComponent<Character>().getDamage();
            if (obj.transform.GetComponent<Turret>().SetDamage(damage))
            {
                //게임 종료
            }
            return;
        }
        if (obj == null) return;
        Character character = obj.transform.parent.GetComponent<Character>();
        character.hp -= this.transform.parent.GetComponent<Character>().getDamage();
        character.setDamageText(this.transform.parent.GetComponent<Character>().getDamage());
        if (character.hp <= 0)
        {
            damageList.Remove(obj);
            switch(this.transform.parent.GetComponent<Character>().id)
            {
                case 12:
                    Passive passive = this.transform.parent.GetComponent<Passive>();
                    passive.SpawnEffect(obj.transform, this.tag);
                    break;
            }
            GameObject.Destroy(obj.transform.parent.gameObject);
        }
    }
    public void onDamageObjects()
    {
        List<GameObject> deathList = new List<GameObject>();
        foreach (GameObject temp in damageList)
        {
            if (temp.name == "HeroTowel" || temp.name == "EnemyTowel")
            {
                if (temp.transform.GetComponent<Turret>().SetDamage(this.transform.parent.GetComponent<Character>().getDamage()))
                {
                    //게임 종료
                }
            }
            else
            {
                Character character = temp.transform.parent.GetComponent<Character>();
                character.hp -= this.transform.parent.GetComponent<Character>().getDamage();
                character.setDamageText(this.transform.parent.GetComponent<Character>().getDamage());
                if (character.hp <= 0)
                {
                    deathList.Add(temp);
                }
            }
        }
        foreach (GameObject temp in deathList)
        {
            damageList.Remove(temp);
            switch (this.transform.parent.GetComponent<Character>().id)
            {
                case 12:
                    Passive passive = this.transform.parent.GetComponent<Passive>();
                    passive.SpawnEffect(temp.transform, this.tag);
                    break;
            }
            GameObject.Destroy(temp.transform.parent.gameObject);
        }
    }
    void AnimationUpdate()
    {
        float tempX = 0;
        if (damageList.Count > 0)
        {
            if (!animator.GetBool("Attack"))
            {
                animator.SetBool("Attack", true);
                switch (this.transform.parent.transform.GetComponent<Character>().id)
                {
                    case 2:
                        if (this.tag == "Enemy") tempX = -0.5f;
                        else if (this.tag == "Hero") tempX = 0.5f;
                        //this.transform.parent.transform.Translate(new Vector3(tempX, 0, 0));
                        StartCoroutine(GotoX(this.transform.parent.gameObject, tempX, 0, 0.12f));
                        break;
                    case 4:
                        Debug.Log("Animator : " + animator.GetBool("Attack"));
                        StartCoroutine(GotoX(this.transform.parent.gameObject, 0, -0.7f, 0.12f));
                        break;
                    case 5:
                        StartCoroutine(GotoX(this.transform.parent.gameObject, 0, -0.7f, 0.12f));
                        break;
                    case 8:
                        StartCoroutine(GotoX(this.transform.parent.gameObject, 0, -0.8f, 0.12f));
                        break;
                }
            }
            else
            {
                switch (this.transform.parent.transform.GetComponent<Character>().id)
                {
                    case 4:
                        if (run)
                        {
                            GameObject obj = getClosestObject();
                            if (obj.name == "HeroTowel" || obj.name == "EnemyTowel") break;
                            float distance = getDistance(new Vector3(this.transform.parent.transform.position.x + (this.transform.parent.transform.GetComponent<BoxCollider2D>().size.x), this.transform.parent.transform.position.y)
                                , new Vector3(obj.transform.parent.position.x - (obj.transform.GetComponent<BoxCollider2D>().size.x / 2.0f), obj.transform.parent.position.y));
                            float speed = distance / 0.5f;
                            Debug.Log("Distance : " + speed);
                            if (gameObject.tag == "Enemy")
                                this.transform.parent.transform.Translate(Vector3.left * Time.deltaTime * speed);
                            else if (gameObject.tag == "Hero")
                                this.transform.parent.transform.Translate(Vector3.right * Time.deltaTime * speed);
                        }
                        break;
                }
            }
        }
        else
        {
            if (animator.GetBool("Attack"))
            {
                animator.SetBool("Attack", false);
                switch (this.transform.parent.transform.GetComponent<Character>().id)
                {
                    case 2:
                        if (this.tag == "Enemy") tempX = 0.5f;
                        else if (this.tag == "Hero") tempX = -0.5f;
                        StartCoroutine(GotoX(this.transform.parent.gameObject, tempX, 0, 0.12f));
                        //this.transform.parent.transform.Translate(new Vector3(tempX, 0, 0));
                        break;
                    case 4:
                        StartCoroutine(GotoX(this.transform.parent.gameObject, 0, 0.7f, 0.12f));
                        break;
                    case 5:
                        StartCoroutine(GotoX(this.transform.parent.gameObject, 0, 0.7f, 0.12f));
                        break;
                    case 8:
                        StartCoroutine(GotoX(this.transform.parent.gameObject, 0, 0.8f, 0.12f));
                        break;
                }
            }
        }
    }

    IEnumerator GotoX(GameObject obj, float x, float y, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (obj != null)
            obj.transform.Translate(new Vector3(x, y, 0));
    }
}
