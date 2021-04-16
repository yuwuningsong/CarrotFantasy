using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCoinController : MonoBehaviour
{
    [SerializeField] int coinNum = 0;
    [SerializeField] GameObject coin = null;
    [SerializeField] int coinNumVisible = 0;

    private List<GameObject> coins = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 爆炸产生金币
    void CreateCoins()
    {
        for (int i = 0; i < coinNumVisible; i++)
        {
            coins.Add(Instantiate(coin, transform));
        }
        CoinManager.coinManager.AddCoins(coinNum);
    }

    // 销毁金币
    void DestroyCoins()
    {
        for (int i = 0; i < coinNumVisible; i++)
        {
            Destroy(coins[0]);
        }
    }
}
