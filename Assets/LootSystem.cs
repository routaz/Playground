using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    public InteractSystem interactable;
    public GameObject carriedObject;
    public bool _canPickupLoot;
    public bool _hasPickedUpLoot;

    [Header("Distance when loot is dropped")]
    [SerializeField] float dropDistance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.CachedObject != null && interactable.CachedObject.GetComponent<LootItem>() != null)
        {
            _canPickupLoot = true;

        }
        else
        {
            _canPickupLoot = false;
        }

        if (Input.GetKeyDown(interactable.primaryActionKey)  && _canPickupLoot)
        {

            if (interactable.CachedObject.GetComponent<LootItem>() && carriedObject == null)
            {
                PickUpLoot();
            }

        }

        if (Input.GetKeyUp(interactable.primaryActionKey) && carriedObject != null)
        {
            _hasPickedUpLoot = true;
    
        }

        if (Input.GetKey(interactable.primaryActionKey) && carriedObject != null && _hasPickedUpLoot)
        {
            DropLootItem();
        }
;

    }

    public void PickUpLoot()
    {
        carriedObject = interactable.CachedObject;
        carriedObject.SetActive(false);

        //FindObjectOfType<LootItemSpawner>().lootSpawnIsActive = false;
    }

    public void DropLootItem()
    {
        Vector3 lootInstantiationPos = new Vector3(transform.position.x, transform.position.y + dropDistance, transform.position.z + dropDistance);
        carriedObject.transform.position = lootInstantiationPos;

        Vector3 randomPos = new Vector3(Random.Range(-2, 2), 1, Random.Range(-2, 2));
        carriedObject.SetActive(true);
        carriedObject.GetComponent<Rigidbody>().AddForce(randomPos, ForceMode.Impulse);
        //carriedObject.GetComponent<LootItem>().ResetLootAndStartSpawnRotation();
        carriedObject = null;
        _hasPickedUpLoot = false;

    }
}
