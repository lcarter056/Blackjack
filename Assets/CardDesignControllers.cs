using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class CardDesignControllers : MonoBehaviour
{
    public Button button1; 
    public Button button2; 
    public Button button3; 
    public Button button4; 
   public GameObject panel; 
   public string cardBacksName;
   public void ClosePanel(){
        panel.SetActive(false);
   }

   public void OpenPanel(){
        panel.SetActive(true);
   }

   public void ChooseCardsOne(){
        GameObject buttonObject = button1.gameObject;
        cardBacksName = buttonObject.GetComponent<Image>().sprite.name;
        //set that sprite to topDeck card

       
        PlayerPrefs.SetString("cardBacksName", cardBacksName); // Save it
        Debug.Log(PlayerPrefs.GetString("cardBacksName", cardBacksName));


        //show text 'selected'
        //close pannel 
    
        
   }
   public void ChooseCardsTwo(){
        
        GameObject buttonObject = button2.gameObject;
        cardBacksName = buttonObject.GetComponent<Image>().sprite.name;
        //set that sprite to topDeck card

        PlayerPrefs.SetString("cardBacksName", cardBacksName); // Save it


        //show text 'selected'
        //close pannel 
        
   }
   public void ChooseCards3(){
        
        GameObject buttonObject = button3.gameObject;
        cardBacksName = buttonObject.GetComponent<Image>().sprite.name;
        //set that sprite to topDeck card

        PlayerPrefs.SetString("cardBacksName", cardBacksName); // Save it
       // PlayerPrefs.Save();
        

        //show text 'selected'
        //close pannel 
        
   }
   public void ChooseCards4(){
        
        GameObject buttonObject = button4.gameObject;
        cardBacksName = buttonObject.GetComponent<Image>().sprite.name;
        //set that sprite to topDeck card

        PlayerPrefs.SetString("cardBacksName", cardBacksName); // Save it


        //show text 'selected'
        //close pannel 
        
   }
   
}
