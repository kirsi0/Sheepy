using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnitures : Item
{
    private object hvAdjust;

    public int TiredValueChange { get; set; }
    public int HealthValueChange { get; set; }

    public Furnitures(int id, string name, ItemType type, string des, int capacity, int buyPrice, int sellPrice, string sprite, int tvAdjust, int hvAdjust)
        : base(id, name, type, des, capacity, buyPrice, sellPrice, sprite)
    {
        this.TiredValueChange = tvAdjust;
        this.HealthValueChange = hvAdjust;
    }

}
