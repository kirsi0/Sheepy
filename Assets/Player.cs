using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int coinAmount = 100;
    private UnityEngine.UI.Slider hpslider, trdslider, hgyslider;

    private Text coinText;

    public int CoinAmount
    {
        get
        {
            return coinAmount;
        }
        set
        {
            coinAmount = value;
            coinText.text = coinAmount.ToString();
        }
    }

    void Start()
    {
        coinText = GameObject.Find("Coin").GetComponentInChildren<Text>();
        coinText.text = coinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        


        //G 随机得到一个物品放到背包里面
        if (Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 10);
            id += 100;
            Bag.Instance.StoreItem(id);
            Bag.Instance.StoreItem(109);
            
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < 5; i++)
            {
                int id = Random.Range(1, 10);
                id += 100;
                Bag.Instance.StoreItem(id);
            }
        }

    }

    /// <summary>
    /// 消费
    /// </summary>
    public bool ConsumeCoin(int amount)
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            coinText.text = coinAmount.ToString();
            return true;
        }
        return false;
    }

    /// <summary>
    /// 赚取金币
    /// </summary>
    /// <param name="amount"></param>
    public void EarnCoin(int amount)
    {
        this.coinAmount += amount;
        coinText.text = coinAmount.ToString();
    }
}
