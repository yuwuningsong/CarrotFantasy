using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEventController : MonoBehaviour
{
    [Header("UI Management")]
    [SerializeField] Button reset = null;           // 重玩本关按钮
    [SerializeField] Button backToMenu = null;      // 回到主菜单按钮
    [SerializeField] GameObject loseUI = null;      // 失败文字
    [SerializeField] GameObject winUI = null;       // 胜利文字

    [Header("Star")]
    [SerializeField] GameObject star01 = null;      // 星星1
    [SerializeField] GameObject star02 = null;      // 星星2
    [SerializeField] GameObject star03 = null;      // 星星3
    [SerializeField] int starLevel = 0;             // 星星等级分界线

    private void Awake()
    {
        reset.onClick.AddListener(ResetLevel);
        backToMenu.onClick.AddListener(BackToMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 暂停游戏
    void StopGame()
    {
        Time.timeScale = 0;
    }

    // 重玩本关
    void ResetLevel()
    {
        Debug.Log("Reset Level!");
        // TO DO: 重新加载本关
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    // 返回选关界面
    void BackToMenu()
    {
        Debug.Log("Back To Menu!");
        SceneManager.LoadScene(0);
        // TO DO: 跳转至选关界面
    }

    // 胜败UI显示
    void GameOver()
    {
        if(GameManager.gameManager.isWin)
        {
            winUI.SetActive(true);
        }
        else
        {
            loseUI.SetActive(true);
        }
    }

    // 胜利时显示星星
    void ShowStars()
    {
        if (GameManager.gameManager.isWin)
        {
            star01.SetActive(true);
            float buildingHealth = gameObject.GetComponent<UIManager>().BuildingHealth;
            if (buildingHealth <= starLevel && buildingHealth >= 0)
            {
                star02.SetActive(true);
                if (buildingHealth == 0)
                {
                    star03.SetActive(true);
                }
            }
        }
    }
}
