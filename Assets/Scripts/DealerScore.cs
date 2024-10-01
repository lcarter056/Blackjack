using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DealerScore : MonoBehaviour
{

    public AnimationClip animationClip;
    public int DealerPoints;
    public GameObject hit_or_draw;
    public bool lose = false;
    public int currPoints;

    public bool playerStays;




    void Start(){
        currPoints = 0;
        playerStays = false;
    }
    public void addPoints(int points){
        currPoints+= points;
        Debug.Log("CurrPoint for Dealer:" + getPoints());
    }

    public int getPoints(){ 
        return currPoints;
    }

}   
