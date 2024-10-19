using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class TargetsController : MonoBehaviour
{
    [SerializeField] Transform [] targets;
    public int targetId;
    CarAIControl carAIControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carAIControl = GetComponent<CarAIControl>();
        carAIControl.SetTarget(targets[targetId]);
    }
    public void NextTarget() { 
        targetId++;
        carAIControl.SetTarget(targets[targetId]);
    }
    
}
