using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour
{
    public Transform player;
    
    public bool hasPlayer = false;
  
    bool untouched = true;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("dit werkt");
        if (other.gameObject.CompareTag("Player"))
            hasPlayer = true;
    }

    void OnTriggerExit(Collider other)
    {
        hasPlayer = false;
    }

    void Update()
    {
        if (untouched && hasPlayer)
        {
            untouched = false;
            MyGlobalSpeedController.SharedInstance.konijnen++; //Dit reffereert naar het manager script die de punten bijhoud
            Destroy(gameObject);
        }

    }

}