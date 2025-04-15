using UnityEngine;

public class BatteryWarning : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        BatteryManager.instance.BatteryChanged += OnInterface;
    }

    private void OnInterface()
    {
        if(BatteryManager.instance.battery == 0)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
    
}
