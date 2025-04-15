using System;
using UnityEngine;

public class BatteryChargeButton : MonoBehaviour
{
    [SerializeField]
    private bool isPressed = false;

    private void Update()
    {
        Charge();
    }

    private void OnMouseDown()
    {
        isPressed = true;
    }
    
    
    private void OnMouseUp()
    {
        isPressed = false;
    }


    private void Charge()
    {
        if (isPressed)
        {
            Debug.Log("Charging");
            BatteryManager.instance.ChargeBattery(20*Time.deltaTime);
        }
    }
}
