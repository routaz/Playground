using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : Interactable
{
    [SerializeField] float howManySecondsBeforeLootResets = 5f;

    //private variables
    private float _resetCounter;
    private bool _isResetting = false; //To be used if LootItemSpawner is in use

    private void Start()
    {
        _resetCounter = 0;
        Initialize();
    }

    public override void Update()
    {
        base.Update();

        if(_isResetting)
        {
            _resetCounter += Time.deltaTime;
            if(_resetCounter >= howManySecondsBeforeLootResets)
            {
                FindObjectOfType<LootItemSpawner>().LootSpawnIsActive = true;
            }
        }
    }

    public override void UseItem(GameObject player)
    {
        base.UseItem(player);
    }

    public void ResetLootAndStartSpawnRotation()
    {
        _isResetting = true;

    }
}
