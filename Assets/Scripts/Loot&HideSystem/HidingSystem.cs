using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    [SerializeField] KeyCode goToHideKey = KeyCode.E;

    //public variables 
    public bool isHiding;

    //private variables
    private Renderer _renderer;

    private bool canGoHiding;
    private bool _hasEnteredHidingSpot;
    private GameObject cachedHidingPlace;

    private InteractSystem interactable;

    private void Start()
    {
        interactable = GetComponent<InteractSystem>();
        _renderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (interactable.CachedObject != null && interactable.CachedObject.GetComponent<HidingSpot>() != null)
        {
            canGoHiding = true;
            cachedHidingPlace = interactable.CachedObject;

            if (Input.GetKeyDown(interactable.primaryActionKey))
            {
                //Add Timer so it's not instant!!!
                if (canGoHiding && isHiding == false)
                {
                    cachedHidingPlace.GetComponent<HidingSpot>().BeginHiding(gameObject);
                    isHiding = true;
                    _renderer.enabled = false;

                }
            }
        }

        if (Input.GetKeyUp(interactable.primaryActionKey) && cachedHidingPlace != null)
        {
            _hasEnteredHidingSpot = true;


        }

        if (Input.GetKeyDown(interactable.primaryActionKey) && isHiding && _hasEnteredHidingSpot == true)
        {
            isHiding = false;
            cachedHidingPlace.GetComponent<HidingSpot>().EndHiding();
            _hasEnteredHidingSpot = false;
            cachedHidingPlace = null;
            _renderer.enabled = true;

        }

 
        
        if(isHiding == false)
        {
            canGoHiding = false;
            cachedHidingPlace = null;

        }
    }

}
