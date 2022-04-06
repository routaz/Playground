using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    //public variables
    public GameObject targetBlock;
    public float buildingBlockCarryDistance = 1;
    public bool isCarryingBlock;

    //private variables
    private bool _canPickUpBlock;
    private bool _pickedUpTheBlock;

    private InteractSystem interactable;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<InteractSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.CachedObject != null && interactable.CachedObject.GetComponent<BuildingBlock>() != null)
        {
            _canPickUpBlock = true;

        }
  
            //Building Block inputs
            if (Input.GetKeyDown(interactable.primaryActionKey) && !isCarryingBlock && _canPickUpBlock)
            {
                PickUpBlock();
            }

            if (Input.GetKeyUp(interactable.primaryActionKey) && _pickedUpTheBlock)
            {
                DropTheBlock();
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f && buildingBlockCarryDistance <= 5)
            {
                buildingBlockCarryDistance += 0.1f;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && buildingBlockCarryDistance >= 0)
            {
                buildingBlockCarryDistance -= 0.1f;

            }

            if (_pickedUpTheBlock)
            {
                CarryingBlock();
            }

            buildingBlockCarryDistance = Mathf.Clamp(buildingBlockCarryDistance, 1.0f, 5.0f);

    }

    private void CarryingBlock()
    {
        Camera playerCamera = Camera.main;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * buildingBlockCarryDistance, Color.blue);
        Vector3 blockPosition = ray.GetPoint(buildingBlockCarryDistance);
        blockPosition.y = Mathf.Clamp(blockPosition.y, .5f, 10.0f);
        interactable.CachedObject.transform.position = blockPosition;
    }

    public void PickUpBlock()
    {
        if (interactable.CachedObject != null && interactable.CachedObject.GetComponent<BuildingBlock>())
        {
            interactable.IsInteractingWithItem = true;
            _pickedUpTheBlock = true;
            interactable.CachedObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void DropTheBlock()
    {
        interactable.IsInteractingWithItem = false;
        _pickedUpTheBlock = false;
        interactable.CachedObject.GetComponent<Rigidbody>().useGravity = true;
        interactable.CachedObject.GetComponent<Interactable>().IsInteracted = false;
        interactable.CachedObject = null;
        buildingBlockCarryDistance = 1.5f;
    }
}
