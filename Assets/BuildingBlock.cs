using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlock : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public override void Update()
    {
        base.Update();
   
    }

    public override void UseItem(GameObject player)
    {
        base.UseItem(player);
    }

}
