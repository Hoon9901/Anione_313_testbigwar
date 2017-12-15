using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
    public Animator animator;
    private Text damageText;
	// Use this for initialization
	void OnEnable () {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damageText = animator.GetComponent<Text>();
	}
    //void Update()
    //{
    //    this.transform.Translate(Vector3.up * Time.deltaTime * 1.5f);
    //}
    public void SetText(string text)
    {
       damageText.text = text;
    }
}
