using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelScript : MonoBehaviour {

    public GameObject MyPanel;


    public void ShowPanel()
    {
        MyPanel.gameObject.SetActive(!MyPanel.activeSelf);
    }

}
