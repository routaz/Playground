using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [SerializeField] public KeyCode primaryActionKey;
    [SerializeField] public KeyCode secondaryActionKey;

    //Getters and Setters
    public GameObject CachedObject { get { return _cachedObject; } set { _cachedObject = value; } }
    public bool IsInteractingWithItem { get { return isInteractingWithItem; } set { isInteractingWithItem = value; } } //This is for building block to keep active color while moved

    //private variables
    private GameObject _cachedObject;
    private GameObject targetObject;
    private GameObject carriedObject;

    private bool isInteractingWithItem;
    private bool _canInteractWithObject;

    private InteractRay interactRay;

    private void Start()
    {
        interactRay = GetComponent<InteractRay>();
    }

    private void Update()
    {
        if (interactRay.GetInteractableGameObject() != null)
        {
            if (interactRay.GetInteractableGameObject().GetComponent<Interactable>())
            {
                targetObject = interactRay.GetInteractableGameObject();
                targetObject.GetComponent<Interactable>().IsInteracted = true;
                _canInteractWithObject = true;
                _cachedObject = targetObject; //Object is cached to be able to change the material after it's not hit by Ray anymore.

                if (Input.GetKeyDown(primaryActionKey) && targetObject != null)
                {
                    targetObject.GetComponent<Interactable>().UseItem(gameObject);
                }
            }
        }
        else if(isInteractingWithItem)
        {
            _cachedObject.GetComponent<Interactable>().IsInteracted = true;
        }
        else
        {
            targetObject = null;
            _canInteractWithObject = false;

            if(_cachedObject != null && !isInteractingWithItem)
            {
                _cachedObject.GetComponent<Interactable>().IsInteracted = false;
            }

            _cachedObject = null;
         
          
        }

    }

}

