using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager coinManager;

    [SerializeField] int coinNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 增加金币数
    public void AddCoins(int coin)
    {
        coinNum += coin;
    }

    // 减少金币数，成功返回true，不成功返回false
    public bool UseCoins(int coin)
    {
        if (coinNum < coin) return false;
        coinNum -= coin;
        return true;
    }
}
