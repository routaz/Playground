using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRay : MonoBehaviour
{
    public Camera playerCamera;
    public float detectionDistance;
    public LayerMask detectionLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

      GetInteractableGameObject();

    }

    public GameObject GetInteractableGameObject()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        Debug.DrawRay(ray.origin, ray.direction * detectionDistance, Color.yellow);
        if (Physics.Raycast(ray, out hit, detectionDistance, detectionLayer))
        {
            return hit.collider.gameObject;
        }
        return null;
        
    }
}
