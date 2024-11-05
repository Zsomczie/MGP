using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public void Vibration() 
    {
        Handheld.Vibrate();
    }
    public void ActivateMenu(GameObject settingsPanel) 
    {
        if (!settingsPanel.gameObject.activeSelf)
        {
            //animating settingsPanel => activate
            settingsPanel.SetActive(true);
            settingsPanel.transform.localScale = Vector3.zero;
            settingsPanel.transform.DOScale(1f, 1f);
        }
        else 
        {
            //animating settingsPanel => deactivate
            settingsPanel.transform.DOScale(0f, 1f).OnComplete(()=> settingsPanel.SetActive(false));
        }
    }
}
