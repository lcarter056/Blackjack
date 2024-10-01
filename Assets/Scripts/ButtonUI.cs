using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonUI : MonoBehaviour
{
    public int HitButton = 2;
    private Hit_or_Draw hitBehavior;

    public void Hit(){
        hitBehavior = FindObjectOfType<Hit_or_Draw>();
        hitBehavior.HitForButton(HitButton);
        HitButton++;
    }
}
