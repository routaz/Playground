using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootReturnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<InteractSystem>().IsInteractingWithItem)
        {
            other.gameObject.GetComponent<InteractSystem>().IsInteractingWithItem = false;
            FindObjectOfType<LootItemSpawner>().lootSpawnIsActive = true;
        }
    }
}
