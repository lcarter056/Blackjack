
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

using System.Xml.Serialization;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//FIX ANIMATIONS, 
public class Hit_or_Draw : MonoBehaviour
{
    private int cardCount = 0;
    private int HitCardCount = 2;
   
    private int y = 1;

    public Sprite displayCardBacks;
    [SerializeField] private GameObject hitButton; 

    public Animator[] animators; 

    [SerializeField] private GameObject readyButton; 

    [SerializeField] private GameObject stayButton; 
    private DealerScore dealerController;
    public Sprite dealerLastCard;
    private PlayerScore playerController;
   
     public List<Sprite> allCards;
     public List<Sprite> currDeck;

     

     public GameObject acePanel;

     
    void Start() {
 
      string name = PlayerPrefs.GetString("cardBacksName");
      Sprite[] topDeckCardSprite = Resources.LoadAll<Sprite>("cardBacks");
      foreach (Sprite card in topDeckCardSprite){
        if (name == card.name){
            displayCardBacks = card;
        }
      SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
   
      spriteRenderer.sprite = displayCardBacks;

      GameObject backcard = GameObject.FindGameObjectWithTag("BottomDeck");
      SpriteRenderer spriteRendererback = backcard.GetComponent<SpriteRenderer>();
      spriteRendererback.sprite = displayCardBacks;
      }

      currDeck = LoadCards();
      acePanel = GameObject.FindGameObjectWithTag("AcePanel");
    
    }
    
    List<Sprite> LoadCards(){
        Sprite[] cardsArray = Resources.LoadAll<Sprite>("52CardDeck");
        allCards = new List<Sprite>(cardsArray);
        //shuffle
        List<Sprite> shuffledCards = Shuffle(allCards);
        return shuffledCards;
    }
    List<Sprite> Shuffle(List<Sprite> cards){
        int random_index; 
        List<Sprite> shuffledCards = new List<Sprite>();
        while(shuffledCards.Count != 52){
            System.Random rng = new System.Random();
            random_index = rng.Next(0, cards.Count);
            shuffledCards.Add(cards[random_index]); 
            cards.RemoveAt(random_index);
        };
        return shuffledCards;
    }
 


    public void DealCards(){ 
        cardCount = 0;
        //first card deal to dealer face up 
        readyButton.GetComponent<Button>().interactable = false;
       
        tempDealUp();
        
        Invoke("RefreshDeck", 3);
        Invoke("Hit", 5f);
        Invoke("RefreshDeck", 6f);
        Invoke("Dealer", 7.6f);
        Invoke("Hit", 8.9f);
        Invoke("RefreshDeck", 10.2f);
        Invoke("enableHitandStay", 10.3f);

        // show buttons
      

       
    }

    public void enableHitandStay(){
        Debug.Log("Enabled hit and stay");
        hitButton.SetActive(true);
        hitButton.GetComponent<Button>().interactable = true;
        stayButton.SetActive(true);
        stayButton.GetComponent<Button>().interactable = true;
    }
    public void tempDealUp(){
      GameObject topCard = GameObject.FindGameObjectWithTag("Top_Deck");
      Animator animator = topCard.GetComponent<Animator>();
      animator.Play("Deal_Card_Up");
      topCard.transform.position += new Vector3(0.4f * y, 0, 0); 
    }
    public void tempDealUpParam(int cardNum){
      GameObject topCard = GameObject.FindGameObjectWithTag("Top_Deck");
      Animator animator = topCard.GetComponent<Animator>();
      animator.Play("Deal_Card_Up");
      topCard.transform.position += new Vector3(0.4f * cardNum , 0, 0); 
    }
    public void Hit(){
      float pos = 0.6f;
      GameObject topCard = GameObject.FindGameObjectWithTag("Top_Deck");
      Animator animator = topCard.GetComponent<Animator>();
      animator.Play("Flip_Card");
      topCard.transform.position += new Vector3(pos* cardCount, 0, 0); 
      cardCount++;
      // remove currCard
      Invoke("RefreshDeck", 2);
     
      }
    
    public void HitForButton(int cardNum){
      float pos = 0.6f;
      GameObject topCard = GameObject.FindGameObjectWithTag("Top_Deck");
      Animator animator = topCard.GetComponent<Animator>();
      animator.Play("Flip_Card");
      topCard.transform.position += new Vector3(pos* cardNum, 0, 0); 
      HitCardCount++;

      hitButton.GetComponent<Button>().interactable = false;
      
      Invoke("RefreshDeck", 2);

      Invoke("EnableHit", 4f);
      

    }

    public void EnableHit(){
        Debug.Log("Enabled hit");
        hitButton.GetComponent<Button>().interactable = true;
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
    
   public void DealerStay(){
        GameObject dealerControls = GameObject.FindGameObjectWithTag("Dealer");
        dealerController = dealerControls.GetComponent<DealerScore>();
       GameObject card = GameObject.FindGameObjectWithTag("DealerFaceDown");
        card.GetComponent<SpriteRenderer>().sprite = currDeck[0];
        string points = currDeck[0].name.Split('_')[1];
        dealerController.addPoints(int.Parse(points));
        currDeck.Remove(currDeck[0]);
   }

   public void showCardPlayer(){
       GameObject card = GameObject.FindGameObjectWithTag("Top_Deck");

        card.GetComponent<SpriteRenderer>().sprite = currDeck[0];
    
        GameObject playerControls = GameObject.FindGameObjectWithTag("Player");
        playerController = playerControls.GetComponent<PlayerScore>();

        string points = currDeck[0].name.Split('_')[1];
        if(points == "ACE"){
            AceButtonUI panelController = acePanel.GetComponent<AceButtonUI>();
            panelController.OpenPanel();
            PauseGame();
        
            //disable hit and stay buttons
           hitButton.GetComponent<Button>().interactable = false;
           stayButton.GetComponent<Button>().interactable = false;
        }
        else {
            playerController.addPoints(int.Parse(points));
        }
        currDeck.Remove(currDeck[0]);      
    }

    
   public void showCardDealer(){
        GameObject[] myCards = GameObject.FindGameObjectsWithTag("Top_Deck");
        GameObject card = myCards[0];

        //change sprite cover for this card
        SpriteRenderer spriteRenderer = card.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currDeck[0];

        GameObject dealerControls = GameObject.FindGameObjectWithTag("Dealer");
        dealerController = dealerControls.GetComponent<DealerScore>();

        string points = currDeck[0].name.Split('_')[1];
        if(points == "ACE"){
            dealerController.addPoints(11);
        }
        else {
            dealerController.addPoints(int.Parse(points));
        }
        currDeck.Remove(currDeck[0]);
   }
       


    public void Dealer(){
        //dealer face down card
        GameObject topCard = GameObject.FindGameObjectWithTag("Top_Deck");
        Animator animator = topCard.GetComponent<Animator>();
        animator.Play("Deal_Cards");
        dealerLastCard = currDeck[0];

        RefreshDeck();
        topCard.tag = "DealerFaceDown";
        currDeck.Remove(currDeck[0]);
   
    }

    public void PauseGame() {
    Time.timeScale = 0; // Pause the game
    foreach (var animator in animators) {
        animator.speed = 0; // Pause animations
    }
}

}



