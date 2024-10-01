using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class winController : MonoBehaviour
{
  public GameObject winPanel; 
    public void OpenPannel(){
        winPanel.SetActive(true);
    }
    public void ClosePannel(){
        winPanel.SetActive(false);
    }
    public void startGame(){
        SceneManager.LoadScene("GameScene");
        ClosePannel();
    }

}
