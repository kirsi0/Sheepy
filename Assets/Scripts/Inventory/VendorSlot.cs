using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class VendorSlot : Slot {
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
       
            if (transform.childCount > 0)
            {
                Item currentItem = transform.GetChild(0).GetComponent<ItemUI>().Item;
                transform.parent.parent.SendMessage("BuyItem", currentItem);
            }
      
        
    }
}
