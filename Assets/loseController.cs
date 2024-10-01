using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

//refactor condense these controllers? 
public class loseController : MonoBehaviour
{
  public GameObject losePanel; 
    public void OpenPannel(){
        losePanel.SetActive(true);
    }
    public void ClosePannel(){
        losePanel.SetActive(false);
    }
    public void startGame(){
        ClosePannel();
        SceneManager.LoadScene("GameScene");
    }

}
