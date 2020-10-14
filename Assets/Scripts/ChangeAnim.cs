using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;
public class ChangeAnim : MonoBehaviour
{
    public apPortrait portrait;
    private int tiredValue;

    void Start()
    { }
    void Update()
    {
        /*portrait.CrossFade("hulahula", 0.5f);
        if(tiredValue >=40 && tiredValue <60)
          portrait.Play("Yawn");*/

    }

    public void changOne()
    {
        portrait.Play("SayHi");
    }

    public  void changTwo()
    {
        portrait.Play("hulahula");
    }

   public void changThree()
    {
        portrait.Play("Yawn");
    }

}
