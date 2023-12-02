using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public PickableType pickableType;

    public Action<Pickable> OnPicked;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collect : "  + pickableType);
            Destroy(gameObject);
        }

        if (OnPicked != null)
        {
            OnPicked(this);
        }
    }
}
