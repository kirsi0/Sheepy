using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    
    #region 单例模式
    private static InventoryManager _instance;

    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                //下面的代码只会执行一次
                _instance = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion
   
    private List<Item> itemList;

    #region ToolTip
    //private ToolTip toolTip;

   // private bool isToolTipShow = false;

   // private Vector2 toolTipPosionOffset = new Vector2(10, -10);
    #endregion

    private Canvas canvas;

    #region PickedItem
    private bool isPickedItem = false;

    public bool IsPickedItem
    {
        get
        {
            return isPickedItem;
        }
    }

    private ItemUI pickedItem;//鼠标选中的物体

    public ItemUI PickedItem
    {
        get
        {
            return pickedItem;
        }
    }
    #endregion

    /// <summary>
    /// 解析物品信息
    /// </summary>
    void ParseItemJson()
    {
        itemList = new List<Item>();
        //文本为在Unity里面是 TextAsset类型
        TextAsset itemText = Resources.Load<TextAsset>("Items");
        string itemsJson = itemText.text;//物品信息的Json格式
        //Debug.Log(itemsJson);
        JSONObject j = new JSONObject(itemsJson);
        foreach (JSONObject temp in j.list)
        {
            string typeStr = temp["type"].str;
            Item.ItemType type = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);//

            //下面的事解析这个对象里面的公有属性
            int id = (int)(temp["id"].n);
            string name = temp["name"].str;
            string description = temp["description"].str;
            int capacity = (int)(temp["capacity"].n);
            int buyPrice = (int)(temp["buyPrice"].n);
            int sellPrice = (int)(temp["sellPrice"].n);
            string sprite = temp["sprite"].str;

            Item item = null;
            switch (type)
            {
              
                
                case Item.ItemType.Consumable:
                    int tvChange = (int)(temp["tvChange"].n);
                    int hvChange = (int)(temp["hvChange"].n);
                    item = new Consumable(id, name, type, description, capacity, buyPrice, sellPrice, sprite, tvChange, hvChange);
                    break;
              
                case Item.ItemType.Furnitures:
                    //
                    int tvAdjust = (int)(temp["tvAdjust"].n);
                    int hvAdjust = (int)(temp["hvAdjust"].n);
                    item = new Furnitures(id, name, type, description, capacity, buyPrice, sellPrice, sprite, tvAdjust,hvAdjust);
                    break;;
                
            }
            itemList.Add(item);
            //Debug.Log(item); 
        }
    }

    public Item GetItemById(int id)
    {
        foreach (Item item in itemList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }

    void Awake()
    {
        ParseItemJson();
    }

    void Start()
    {
        ParseItemJson();

    }
    void Update()
    {
        
        

        //物品丢弃的处理
        if (isPickedItem && Input.GetMouseButtonDown(0) && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1) == false)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }

    /*public void ShowToolTip(string content)
    {
        if (this.isPickedItem) return;
        isToolTipShow = true;
        toolTip.Show(content);
    }

    public void HideToolTip()
    {
        isToolTipShow = false;
        toolTip.Hide();
    }

    //捡起物品槽指定数量的物品
    public void PickupItem(Item item, int amount)
    {
        PickedItem.SetItem(item, amount);
        isPickedItem = true;

        PickedItem.Show();
        this.toolTip.Hide();
        //如果我们捡起了物品，我们就要让物品跟随鼠标
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
        pickedItem.SetLocalPosition(position);
    }

    /// <summary>
    /// 从手上拿掉一个物品放在物品槽里面
    /// </summary>
    public void RemoveItem(int amount = 1)
    {
        PickedItem.ReduceAmount(amount);
        if (PickedItem.Amount <= 0)
        {
            isPickedItem = false;
            PickedItem.Hide();
        }
    }*/

    public void SaveInventory()
    {
        Bag.Instance.SaveInventory();
        PlayerPrefs.SetInt("CoinAmount", GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CoinAmount);
    }

    public void LoadInventory()
    {
        Bag.Instance.LoadInventory();
       
        if (PlayerPrefs.HasKey("CoinAmount"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CoinAmount = PlayerPrefs.GetInt("CoinAmount");
        }
    }

}
