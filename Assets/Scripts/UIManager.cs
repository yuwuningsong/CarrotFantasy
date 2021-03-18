using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text monsterNum = null;    // 清除的怪物波数UI文本
    [SerializeField] Text monsterNumTotal = null;   // 总共的怪物波数UI文本
    [SerializeField] Slider slider = null;          // 清除的怪物条

    public int MonsterNum { get; set; }         // 清除的怪物波数
    public int MonsterNumTotal { get; set; }    // 总共的怪物波数

    private void Awake()
    {
        monsterNum.text = MonsterNum.ToString();
        monsterNumTotal.text = MonsterNumTotal.ToString();

        slider.maxValue = MonsterNumTotal;
        slider.value = MonsterNum;
    }
}
