using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public void PointerEnter(){
        GameObject.Find("StartButton").transform.localScale = new Vector3(1.4f ,1.4f);
    }

    public void PointerExit(){
        GameObject.Find("StartButton").transform.localScale = new Vector3(1.2f ,1.2f);
        
    }
}
