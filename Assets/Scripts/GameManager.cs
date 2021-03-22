using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    [Header("List")]
    [SerializeField] List<BuildingDeadController> buildings = null;      // 房屋集合
    [SerializeField] List<GameObject> monsters = null;                      // 怪物集合

    [Header("UI")]
    [SerializeField] GameObject loseUI = null;      // 失败界面

    [Header("Monster")]
    [SerializeField] GameObject monster01 = null;   // 怪物种类
    [SerializeField] GameObject monster02 = null;
    [SerializeField] Transform startPoint = null;   // 怪物生成点
    [SerializeField] int monsterNum = 0;            // 怪物总数
    [SerializeField] float monsterCD = 0f;          // 怪物生成CD

    private void Awake()
    {
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreateMonster");
    }

    // Update is called once per frame
    void Update()
    {
        Lose();
        if (monsters.Count >= monsterNum) StopCoroutine("CreateMonster");
    }

    // 房屋摧毁删除
    public void DestroyBuilding(BuildingDeadController building)
    {
        buildings.Remove(building);
    }

    // 游戏失败逻辑
    void Lose()
    {
        if (buildings.Count <= 0)
        {
            // TO DO: 只调用一次
            Debug.Log("GameOver!");
            loseUI.SetActive(true);
        }
    }

    // 怪物生成
    IEnumerator CreateMonster()
    {
        while (true)
        {
            GameObject monster = Instantiate(monster01, startPoint);  
            monsters.Add(monster);
            Debug.Log(monsters.Count);
            yield return new WaitForSeconds(monsterCD);
        }
    }
}
