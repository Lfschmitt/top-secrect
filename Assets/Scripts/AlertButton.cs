using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertButton : MonoBehaviour {

    public GameObject panel;
    public GameObject buttonAlert;

    public void SetPanel(bool enable) {
        panel.SetActive(enable);
	}

    public void SetButton(bool enable)
    {
        buttonAlert.SetActive(enable);
    }
}
