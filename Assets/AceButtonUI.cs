using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AceButtonUI : MonoBehaviour
{
    public Animator[] animators; 
    [SerializeField] private GameObject acePannel; 
    [SerializeField] private GameObject hitButton; 
    [SerializeField] private GameObject stayButton; 
    private PlayerScore playerController;

  

  public void OpenPanel(){
    acePannel.SetActive(true);
  }
  public void addElevenPoints(){
    GameObject playerControls = GameObject.FindGameObjectWithTag("Player");
    playerController = playerControls.GetComponent<PlayerScore>();
    playerController.addPoints(11);
    acePannel.SetActive(false);
    

  //enable hit and stay buttons
  
    hitButton.GetComponent<Button>().interactable = true;
    stayButton.GetComponent<Button>().interactable = true;
    ResumeGame();

    
  }

  public void addOnePoint(){
    GameObject playerControls = GameObject.FindGameObjectWithTag("Player");
    playerController = playerControls.GetComponent<PlayerScore>();
    playerController.addPoints(1);
    
    
    acePannel.SetActive(false);

     hitButton.GetComponent<Button>().interactable = true;
     stayButton.GetComponent<Button>().interactable = true;
     ResumeGame();
  }

    public void ResumeGame() {
    Time.timeScale = 1;
    foreach (var animator in animators) {
        animator.speed = 1;
    }
}

}
