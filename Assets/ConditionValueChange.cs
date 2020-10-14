using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionValueChange : MonoBehaviour
{
    public Slider hpslider, tirslider, hunslider;
    
    // Start is called before the first frame update
    void Start()
    {
      
        hpslider.value = 73;
        tirslider.value = 20;
        hunslider.value = 90;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            hpslider.value -= 10;


        }
    }


    public void ChangeTest()
    {
        int it = Random.Range(-5, 5);
        hpslider.value += it;
        it = Random.Range(-5, 5);
        tirslider.value += it;
        it = Random.Range(-5, 5);
        hunslider.value += it;

    }
    public void ChangeValue(int hvChange, int tvChange, int hunChange)
    {
        hpslider.value += hvChange;
        tirslider.value += tvChange;
        hunslider.value += hunChange;

    }

}
