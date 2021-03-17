using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEventController : MonoBehaviour
{
    [SerializeField] Button reset = null;           // 重玩本关按钮
    [SerializeField] Button backToMenu = null;      // 回到主菜单按钮

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
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    // 返回选关界面
    void BackToMenu()
    {
        Debug.Log("Back To Menu!");
        // TO DO: 跳转至选关界面
    }
}
