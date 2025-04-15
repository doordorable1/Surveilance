using UnityEngine;

public class BatteryFill : MonoBehaviour
{
    public SpriteRenderer sr;
    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SetFill();
        BatteryManager.instance.BatteryChanged += SetFill;
    }


    public void SetFill()
    {
        sr.size = new Vector2(0.75f, BatteryManager.instance.batteryPercentage/100*2.05f);
    }
}
