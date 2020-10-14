using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour, IPointerExitHandler {

    #region ToolTip
    //public Text text { get; private set; }
   // public Button  UseBtn { get; private set; }
    //public Button SellBtn { get; private set; }
    public string Description { get; private set; }
    #endregion

   // private Text toolTipText;
    private Text contentText;
    private CanvasGroup canvasGroup;


    #region UI Component

    private Text itemText;

    private Text ItemText
    {
        get
        {
            if (itemText == null)
            {
                itemText = transform.Find("ItemText").GetComponent<Text>();
            }
            return itemText;
        }
    }

    #endregion

  

    public void SetText(string description)
    {

        ItemText.text = description;

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetLocalPotion(Vector3 position)
    {
        transform.localPosition = position;
    }

    public void OnPointerExit(PointerEventData eventData)
        
    {
        Debug.Log("1111111");
        Hide();
    }

}
