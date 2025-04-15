using System;
using TMPro;
using UnityEngine;

public class BatteryManager : MonoBehaviour
{
    public static BatteryManager instance;
    public float batteryPercentage;
    public int maxBattery = 100;
    public float battery = 100;
    public Action BatteryChanged;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InitBattery();
    }
    
    public void InitBattery()
    {
        battery = maxBattery;
        batteryPercentage = 100;
        BatteryChanged?.Invoke();
    }
    
    public void UseBattery(float amount)
    {
        battery -= amount/2;
        if (battery < 0)
        {
            battery = 0;
        }
        batteryPercentage = battery / maxBattery * 100;
        BatteryChanged?.Invoke();
    }
    
    public void ChargeBattery(float amount)
    {
        battery += amount*2;
        if (battery > maxBattery)
        {
            battery = maxBattery;
        }
        batteryPercentage = battery / maxBattery * 100;
        BatteryChanged?.Invoke();
    }
}
