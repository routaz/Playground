using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDuplicator : Interactable
{
    //public variables
    public ParticleSystem sparks;
    public GameObject duplicatorInput;
    public GameObject duplicatorOutput;
    public GameObject cachedGameobject;

    
    //public Collider[] hitColliders; --> to be used with overlapBox if needed.

    private void Start()
    {
        Initialize();
       
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();

            

    }

    public override void UseItem(GameObject player)
    {
        base.UseItem(player);
        CheckDuplicatedItem();
        DuplicateItem();
        sparks.Play();

    }

    private void CheckDuplicatedItem()
    {
        Physics.Raycast(duplicatorInput.transform.position, duplicatorInput.transform.up, out RaycastHit hit, 1f);
        if(hit.collider != null)
        {
            cachedGameobject = hit.collider.gameObject;
        }
        else
        {
            cachedGameobject = null;
        }

        //THIS IS FOR CASTING OVERLAP BOX TO MAKE WIDER AREA OF DETECTION ON INPUT PLATFORM
        /*
        Vector3 castStart = new Vector3(duplicatorInput.transform.position.x, duplicatorInput.transform.position.y + 0.1f, duplicatorInput.transform.position.z);
        Vector3 castSize = new Vector3(duplicatorInput.transform.localScale.x, duplicatorInput.transform.localScale.y, duplicatorInput.transform.localScale.z);

        hitColliders = Physics.OverlapBox(castStart, castSize / 2, duplicatorInput.transform.rotation);
        int i = 0;
        while (i < hitColliders.Length && i == 0)
        {
             i++;
        }
        if(hitColliders.Length > 0)
        {
            cachedGameobject = hitColliders[0].gameObject;
        }
        else
        {
            cachedGameobject = null;
        }
        */
        
       
    }

    private void DuplicateItem()
    {
        if (cachedGameobject != null)
        {
            Vector3 spawnPos = new Vector3(duplicatorOutput.transform.position.x, duplicatorOutput.transform.position.y + 2f, duplicatorOutput.transform.position.z);
            Instantiate(cachedGameobject, spawnPos, Quaternion.identity);
        }
    }

}
