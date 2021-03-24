using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text monsterNum = null;    // 清除的怪物波数UI文本
    [SerializeField] Text monsterNumTotal = null;   // 总共的怪物波数UI文本
    [SerializeField] Slider monsterSlider = null;   // 清除的怪物条
    [SerializeField] Text healthText = null;        // 房屋摧毁度UI文本
    [SerializeField] Slider buildingHealth = null;   // 房屋摧毁度

    public int MonsterNum {                 // 清除的怪物波数
        get => GameManager.gameManager.monsterDes;
    }         
    public int MonsterNumTotal {            // 总共的怪物波数
        get => GameManager.gameManager.monsterNumTotal;
    }  
    public float BuildingHealth{ get; set; }

    private void Awake()
    {
        monsterNum.text = MonsterNum.ToString();
        monsterNumTotal.text = MonsterNumTotal.ToString();

        monsterSlider.maxValue = MonsterNumTotal;
        monsterSlider.value = MonsterNum;

        BuildingHealth = (GameManager.gameManager.healthTotal - GameManager.gameManager.buildingHealth) / GameManager.gameManager.healthTotal * 100;
        healthText.text = ((int)BuildingHealth).ToString();
        buildingHealth.value = (int)BuildingHealth;
        Debug.Log(BuildingHealth);
    }
}
