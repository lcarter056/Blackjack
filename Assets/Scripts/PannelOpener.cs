using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelOpener : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    public void OpenPannel(){
        Panel.SetActive(true);
    }
    public void ClosePannel(){
        Panel.SetActive(false);
    }
}