using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] GameObject loseUI = null;      // 失败界面
    [SerializeField] List<BuildingDeadController> buildings = null;      // 房屋集合

    private void Awake()
    {
        gameManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lose();
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
}
