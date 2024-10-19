using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class ChangeCarView : MonoBehaviour
{
    private AutoCam autoCam;
    [SerializeField] Transform[] cars;
    private int carId;
    // Start is called before the first frame update
    void Start()
    {
        autoCam = GetComponent<AutoCam>();
        autoCam.SetTarget(cars[carId]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            ChangeView();
    }
    private void ChangeView() { 
        carId = (++carId) % cars.Length;
        autoCam.SetTarget(cars[carId]);
    }
}
