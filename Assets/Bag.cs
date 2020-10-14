using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : Inventory
{
    //gameobject.setactive(T/F)控制显示隐藏
    #region 单例模式
    private static Bag _instance;
    public static Bag Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("BagPanel").GetComponent<Bag>();
            }
            return _instance;
        }
    }
    #endregion
}
