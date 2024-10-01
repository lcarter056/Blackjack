using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BustedUI : MonoBehaviour
{
    public GameObject bustedPanel;
    // Start is called before the first frame update
    public void OpenPanel(){
        bustedPanel.SetActive(true);
    }
    public void closePanel(){
        bustedPanel.SetActive(false);
    }
}
