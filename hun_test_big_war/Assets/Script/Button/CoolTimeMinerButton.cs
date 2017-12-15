using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeMinerButton : MonoBehaviour {
    public Image skillFilter;
    private float currentCoolTIme;
    private float coolTime;
    private bool canUseSkill;
    public int loc;

    // Use this for initialization
    void Start()
    {
        canUseSkill = true;
        skillFilter.fillAmount = 0;
        coolTime = GameObject.Find("Main Camera").GetComponent<MinerSpawn>().miner[loc].GetComponent<Miner>().coolTime;
    }

    public void UseSkill()
    {
        int price = GameObject.Find("Main Camera").GetComponent<MinerSpawn>().miner[loc].GetComponent<Miner>().price;
        if (!canUseSkill) return;
        if (StageInfo.g_Money[0] < price) return;
        Debug.Log("price : " + price);
        StageInfo.g_Money[0] -= price;
        currentCoolTIme = coolTime;
        skillFilter.fillAmount = 1;
        StartCoroutine("Cooltime");
        canUseSkill = false;
        StartCoroutine("CoolTimeCounter");
        GameObject.Find("Main Camera").GetComponent<MinerSpawn>().spawnHeroMiner();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Cooltime()
    {
        while (skillFilter.fillAmount > 0)
        {
            skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

            yield return null;
        }
        canUseSkill = true;

        yield break;
    }

    IEnumerator CoolTimeCounter()
    {
        while (currentCoolTIme > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentCoolTIme -= 1.0f;
        }
        yield break;
    }
}
