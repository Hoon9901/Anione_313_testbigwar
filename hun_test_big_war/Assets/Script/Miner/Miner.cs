using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour {
    private Vector3[] loc;
    private Vector3[] mineLoc;
    private Animator animator;
    public int MinerID;
    public float MoveSpeed;
    public float coolTime;
    public float MineSpeed;
    public int price;
    public string name;
    public int moneyAmount;
    public Grade_Enum grade;
    private bool goHome;

	// Use this for initialization
	void Start () {
        goHome = false;
        loc = new Vector3[2]; mineLoc = new Vector3[2];
        loc[0] = GameObject.Find("Main Camera").GetComponent<StageInfo>().heroMineSpawnLoc.position; 
        mineLoc[0] = GameObject.Find("Main Camera").GetComponent<StageInfo>().heroMineMiningLoc.position;
        loc[1] = GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyMineSpawnLoc.position; 
        mineLoc[1] = GameObject.Find("Main Camera").GetComponent<StageInfo>().enemyMineMiningLoc.position;
        animator = gameObject.GetComponent<Animator>();
        this.GetComponent<SpriteRenderer>().flipX = (this.tag == "Hero") ? true : false;
	}
	
	// Update is called once per frame
	void Update () {
        if (animator.GetBool("Mine")) return;

        int tTag = this.tag == "Hero" ? 0 : 1;
        Debug.Log("TAG : " + this.tag);
        if (goHome)  {
            if (tTag == 0) this.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
            else this.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);

            if (Mathf.Abs((this.transform.position.x - loc[tTag].x)) < 0.1) { 
                goHome = false; 
                this.GetComponent<SpriteRenderer>().flipX = (tTag == 0) ? true: false;
                StageInfo.g_Money[tTag] += moneyAmount;
            }
        } else {
            if (tTag == 0) this.transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
            else this.transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);

            if (Mathf.Abs((this.transform.position.x - mineLoc[tTag].x)) < 0.1)
            {
                animator.SetBool("Mine", true);
                StartCoroutine(MineTimer(tTag, MineSpeed));
            }
        }
	}
    IEnumerator MineTimer(int tTag, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        goHome = true;
        this.GetComponent<SpriteRenderer>().flipX = (tTag == 0) ? false : true;
        animator.SetBool("Mine", false);
    }
}
