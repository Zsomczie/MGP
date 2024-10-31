using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public void Vibration() 
    {
        Handheld.Vibrate();
        Camera.main.transform.DOPunchPosition(Vector3.one, 1f, 10);
    }
    public void ActivateMenu(GameObject menuPanel) 
    {
        if (!menuPanel.gameObject.activeSelf) 
        {
            menuPanel.SetActive(!menuPanel.gameObject.activeSelf);
            menuPanel.transform.localScale = Vector3.zero;
            menuPanel.transform.DOScale(1f, 1f).OnComplete(() => menuPanel.transform.DOKill());
        }
        else
        {
            menuPanel.transform.DOScale(0f, 1f).OnComplete(() =>
            {
                menuPanel.transform.DOKill();
                menuPanel.SetActive(!menuPanel.gameObject.activeSelf);
            });
            
        }
        
    }
}
