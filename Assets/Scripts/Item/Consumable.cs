using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int TiredValueChange { get;set; }
    public int HealthValueChange { get; set; }

    public Consumable(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice, string sprite, int tvChange, int hvChange)
        :base(id,  name, type, des, capacity, buyPrice,sellPrice, sprite)
    {
        this.TiredValueChange = tvChange;
        this.HealthValueChange = hvChange;
    }
   

}
