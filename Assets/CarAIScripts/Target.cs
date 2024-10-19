using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Target : MonoBehaviour
{
    List<GameObject> sentGmos;
    private void Start() {
        sentGmos = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.attachedRigidbody != null && !sentGmos.Contains(other.attachedRigidbody.gameObject)) {
            other.attachedRigidbody.SendMessage("NextTarget");
            Debug.Log(other.name);
            sentGmos.Add(other.attachedRigidbody.gameObject);
        }        
    }
}
