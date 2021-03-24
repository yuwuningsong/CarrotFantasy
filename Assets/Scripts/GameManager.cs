using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    [Header("List")]
    [SerializeField] List<GameObject> buildings = null;      // 房屋集合
    [SerializeField] public List<GameObject> monsters = null;                      // 怪物集合

    [Header("UI")]
    [SerializeField] GameObject overUI = null;      // 结束界面
    public bool isWin = false;                      // 是否获胜

    [Header("Monster")]
    [SerializeField] GameObject monster01 = null;   // 怪物种类
    [SerializeField] GameObject monster02 = null;
    [SerializeField] Transform startPoint = null;   // 怪物生成点
    [SerializeField] public int monsterNumTotal = 0;     // 怪物总数
    [SerializeField] float monsterCD = 0f;          // 怪物生成CD

    public int buildingHealth = 0;                  // 房屋当前血量
    public int healthTotal = 10;                     // 房屋总血量
    public int monsterNum = 0;                      // 已生成怪物数

    private void Awake()
    {
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeHealth();
        StartCoroutine("CreateMonster");
    }

    // Update is called once per frame
    void Update()
    {
        SyncHealth();
        GameOver();
        if (monsterNum >= monsterNumTotal) StopCoroutine("CreateMonster");
    }

    // 房屋摧毁删除
    public void DestroyBuilding(GameObject building)
    {
        buildings.Remove(building);
    }

    // 怪物摧毁删除
    public void DestroyMonster(GameObject monster)
    {
        monsters.Remove(monster);
    }

    // 游戏胜败逻辑
    void GameOver()
    {
        if (buildings.Count <= 0)
        {
            isWin = false;
            overUI.SetActive(true);
        }
        else if (monsterNum > 0 && monsters.Count <= 0 && healthTotal > 0)
        {
            isWin = true;
            overUI.SetActive(true);
        }
    }

    // 怪物生成
    IEnumerator CreateMonster()
    {
        while (true)
        {
            GameObject monster = Instantiate(monster01, startPoint);  
            monsters.Add(monster);
            monsterNum++;
            yield return new WaitForSeconds(monsterCD);
        }
    }

    // 初始化房屋血量数据
    void InitializeHealth()
    {
        foreach(GameObject building in buildings)
        {
            healthTotal += building.GetComponent<BuildingHurtController>().totalHealth;
        }
    }
    
    // 同步房屋血量数据
    void SyncHealth()
    {
        buildingHealth = 0;
        foreach (GameObject building in buildings)
        {
            buildingHealth += building.GetComponent<BuildingHurtController>().health;
        }
    }

}
