using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerScore : MonoBehaviour
{
     
    public GameObject lossPanel;
    public int currPoints;
    public GameObject bustedPanel;

    public bool playerStays = false;

    void Start(){
        currPoints = 0;
    }

    public void addPoints(int points){
       
       currPoints += points;
       int totalPoints = getScore();
       Debug.Log("currPoints" + totalPoints);
       if (totalPoints > 21){
            bustedPanel.SetActive(true);
            //wait for animation to play
            Invoke("LoserScreen", 4f);

       }
      
    }

    public void LoserScreen(){
        SceneManager.LoadScene("LoseScene"); 
    }
    
    public int getScore(){
       return currPoints;
    }



}


