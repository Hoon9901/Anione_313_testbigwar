using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {
    private static FloatingText popupText;
    private static FloatingText enemyText;
    private static GameObject canvas;
    public static void Initialize()
    {
        canvas = GameObject.Find("DamageEffect").transform.GetChild(0).gameObject;
        if(!popupText)
            popupText = Resources.Load<FloatingText>("prefab/" + MyInfo.settingFont.ToString());
        if(!enemyText)
            enemyText = Resources.Load<FloatingText>("prefab/" + StageInfo.enemyFont.ToString());
    }
    
	public static void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = new Vector2(location.position.x + UnityEngine.Random.Range(-.5f, .5f), location.position.y + UnityEngine.Random.Range(-.5f, .5f) + 1.5f);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
    public static void CreateFloatingTextEnemy(string text, Transform location)
    {
        FloatingText instance = Instantiate(enemyText);
        Vector2 screenPosition = new Vector2(location.position.x + UnityEngine.Random.Range(-.5f, .5f), location.position.y + UnityEngine.Random.Range(-.5f, .5f) + 1.5f);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }

}
