using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品基类
/// </summary>
public class Item {

    public int ID { get; set; }
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public string Sprite { get; set; } //物品路径

    public enum ItemType
    {
        Consumable,
        Furnitures
    }

    public Item(int id, string name, ItemType type,  string des, int capacity, int buyPrice, int sellPrice, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.Description = des;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary> 
    /// 得到提示面板应该显示什么样的内容
    /// </summary>
    /// <returns></returns>
    public virtual string GetToolTipText()
    {
        
        string text = string.Format("{0}\n<size=20>购买价格：{1} 出售价格：{2}</size>\n<color=yellow><size=20>", Name, BuyPrice, SellPrice, Description);
        return text;
    }
}
