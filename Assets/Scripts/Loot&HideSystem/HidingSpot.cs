using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : Interactable
{
    public bool turnOffRenderer = false;
    public bool isOccupied = false;

    public GameObject playerWhoIsHiding;
    public GameObject cachedPlayer;

    //private variables
    private GameObject hidingPlaceExit;
    

    // Start is called before the first frame update
    void Start()
    {
        Initialize();


        if (turnOffRenderer)
        {
            _renderer.enabled = false;
        }

        if(playerWhoIsHiding == null)
        {
            isOccupied = false;
        }

        hidingPlaceExit = gameObject.transform.GetChild(0).gameObject;
    }

    public override void UseItem(GameObject player)
    {
        base.UseItem(player);
    }

    public void BeginHiding(GameObject player)
    {
        isOccupied = true;
        playerWhoIsHiding = player;
        playerWhoIsHiding.transform.position = transform.position;
        playerWhoIsHiding.transform.rotation = transform.rotation;
        Debug.Log(playerWhoIsHiding.name + " is hiding, you should disable controls maybe?");
    }

    public void EndHiding()
    {
        isOccupied = false;
        playerWhoIsHiding.transform.position = hidingPlaceExit.transform.position;
        playerWhoIsHiding.transform.rotation = hidingPlaceExit.transform.rotation;
        playerWhoIsHiding = null;
    }
}
