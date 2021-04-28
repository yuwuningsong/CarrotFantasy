using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject selectMenu = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 开始游戏
    public void StartGame()
    {
        gameObject.SetActive(false);
        selectMenu.SetActive(true);
    }

    // 选择关卡
    public void SelectLevel()
    {
        // TO DO: 选关逻辑
        SceneManager.LoadScene(0);
    }
}
