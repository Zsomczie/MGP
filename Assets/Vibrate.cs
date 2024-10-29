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
}
