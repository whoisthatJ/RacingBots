using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private float horizontal;
        private float vertical;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        public void Accelerate() {
            vertical = 1;
        }
        public void Break() {
            vertical = -1;
        }
        public void ResetAcceleration() { 
            vertical = 0; 
        }
        public void Left() {
            horizontal = -1;
        }
        public void Right() {
            horizontal = 1;
        }
        public void ResetSteer() { 
            horizontal = 0;
        }
        private void FixedUpdate()
        {
            // pass the input to the car!
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
#if !MOBILE_INPUT
            float handbrake = Input.GetAxis("Jump");
            m_Car.Move(horizontal, vertical, vertical, handbrake);
#else
            m_Car.Move(horizontal, vertical, vertical, 0f);
#endif
        }
    }
}
