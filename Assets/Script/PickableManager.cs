using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableManager : MonoBehaviour
{
    private List<Pickable> _pickableList = new List<Pickable>();

    [SerializeField] private Player player;

    [SerializeField] private ScoreManager scoreManager;

    private void Start()
    {
        InitPickable();
        scoreManager.SetMaxScore(_pickableList.Count);
    }

    private void InitPickable()
    {
        Pickable[] pickableObjects = GameObject.FindObjectsOfType<Pickable>();
        for (int i = 0; i < pickableObjects.Length; i++)
        {
            _pickableList.Add(pickableObjects[i]);
            pickableObjects[i].OnPicked += OnPickablePicked;
        }

        Debug.Log("pickable List : " + _pickableList.Count);
    }

    private void OnPickablePicked(Pickable pickable)
    {
        _pickableList.Remove(pickable);

        if (_pickableList.Count <= 0)
        {
            Debug.Log("Win");
        }

        if (pickable.pickableType == PickableType.PowerUp)
        {
            player.PickPowerUp();
        }

        if (scoreManager != null)
        {
            scoreManager.AddScore(1);
        }
    }
}
