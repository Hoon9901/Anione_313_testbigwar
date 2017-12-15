using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInfo_db : MonoBehaviour {
    // Singleton 객체 사용은 MyInfo_db.instace;
    public static MyInfo_db instance = null; 
    // 상점에서 깐 카드팩에 나온 유닛을 담을 변수
    public List<int> cardUnit = new List<int>();
    public int[] cardUnit_count = new int[13]; // 유닛 갯수
    // MyInfo에 대한 변수
    public float money = 0;
    public float crystal = 0;
    void Awake()
    {
        // 싱글턴으로 초기화
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject); // 이객체는 씬이 전환되도 Destroy 안됨.
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("MyInfo_db Awake() - 중복 제거");
            Destroy(this.gameObject);
        }

        // Code
        instance.MyInfo_Init();
    }
    // 최초 초기화
    public void MyInfo_Init()
    {
        for (int i = 0; i < 13; i++)
        {
            cardUnit_count[i] = 0;
        }
    }
    // 모든 데이터들을 초기화합니다
    public void MyInfo_reset_All_Data()
    {
        Debug.Log("Myinfo_db 초기화 실행");
        MyInfo_db.instance.money = MyInfo_db.instance.crystal = 1000000;
        instance.cardUnit.Clear();
    }
    // 상정에서 깐 유닛 ID 를을 cardUnit ArrayList 에 Add()
    public void MyInfo_cardUnit_val_Load(int cardUnitID)
    {
        instance.cardUnit.Add(cardUnitID);
    }
    // CardUnit 배열에 들어있는 모든 값을 출력합니다
    public void MyInfo_cardUnit_val_AllShow()
    {
        for (int i = 0; i < cardUnit.Count ; i++)
        {
            Debug.Log("MyInfo_db.cardUnit[" + i + "] = " + MyInfo_db.instance.cardUnit[i] + "\n");
        }
    }
}
