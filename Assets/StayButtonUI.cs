using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StayButtonUI : MonoBehaviour
{
    public int dealCardNum = 2;

    void Update(){
        GameObject dealerControls = GameObject.FindGameObjectWithTag("Dealer");
        DealerScore dealerController = dealerControls.GetComponent<DealerScore>();
       
        if (dealerController.getPoints() > 16){
            getWinner();
        }
    }
    public void StayPressed(){
        //player turn over an animation 
        GameObject dealerCard = GameObject.FindGameObjectWithTag("DealerFaceDown");
        GameObject topCard = GameObject.FindGameObjectWithTag("Top_Deck");
   
        Animator originalAnimator = topCard.GetComponent<Animator>();
        Animator dealerAnimator = dealerCard.GetComponent<Animator>();
       //GOOD
        RuntimeAnimatorController controller = originalAnimator.runtimeAnimatorController;
        
         foreach (AnimationClip clip in controller.animationClips){
                //"Stay_action"
                if (clip.name == "Stay_action"){
                    dealerAnimator.Play("Stay_action");
                    break;
                }         
        }  

         DealerStay();
    
        //then do this 
        Invoke("getWinner", 15f);
        
    }
    public void getWinner(){
        GameObject dealerControls = GameObject.FindGameObjectWithTag("Dealer");
        DealerScore dealerController = dealerControls.GetComponent<DealerScore>();
    
         GameObject playerControls = GameObject.FindGameObjectWithTag("Player");
         PlayerScore playerController = playerControls.GetComponent<PlayerScore>();

         if (dealerController.getPoints() >= 21){
            Invoke("loadWin", 3f);
         }
        
         else if(dealerController.getPoints() <= playerController.getScore()){
            Invoke("loadWin", 3f);
        }
        else {
            Invoke("loadLose", 3f);
        }
    }
    
    public void DealerStay(){
        GameObject dealerControls = GameObject.FindGameObjectWithTag("Dealer");
        DealerScore dealerController = dealerControls.GetComponent<DealerScore>();
       
        //deal card 
         if (dealerController.getPoints() <= 16){
            Debug.Log("giving dealer new card");
            Invoke("NewDealerCard", 9f);
            Invoke("RefreshDeck", 11f);
            Invoke("DealerStay", 13f);
        
            }
    }
    public void loadWin(){
          SceneManager.LoadScene("WinScene");
    }
    public void loadLose(){
          SceneManager.LoadScene("LoseScene");
    }

    public void NewDealerCard(){
         GameObject dealerCard = GameObject.FindGameObjectWithTag("DealerFaceDown");
         GameObject hitControls = GameObject.FindGameObjectWithTag("Top_Deck");
         Hit_or_Draw hitController = hitControls.GetComponent<Hit_or_Draw>();
         hitController.tempDealUpParam(dealCardNum);
         dealerCard.transform.position += new Vector3(0.5f * 3, 0, 0);
         dealCardNum++;
    }


    public void RefreshDeck(){

       GameObject topDeckCard = GameObject.FindGameObjectWithTag("Top_Deck");

       GameObject newCard = Instantiate(topDeckCard, new Vector3(-2.0f, 1.5f, 0), Quaternion.identity);
      
       Sprite[] cardBacks = Resources.LoadAll<Sprite>("52CardDeck");
       newCard.GetComponent<SpriteRenderer>().sprite = cardBacks[9]; 
     
       //change other cards tag to Card
       topDeckCard.tag = "Card"; 
       topDeckCard.name = "Card";
       newCard.tag = "Top_Deck";
       newCard.name = "Top_Deck";
   
    }
}
