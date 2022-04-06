using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawnPoint : MonoBehaviour
{

    private MeshRenderer _renderer;
    private BoxCollider _collider;
    public bool turnOffRenderer = false;

    public bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<BoxCollider>();

        if (turnOffRenderer)
        {
            _renderer.enabled = false;
        }
        _collider.isTrigger = true;
        
    }

    public void HandleOccupationStatus()
    {
        isOccupied = !isOccupied;
    }
}
