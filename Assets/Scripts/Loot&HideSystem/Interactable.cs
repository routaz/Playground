using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private Material _itemInteractableMaterial;

    //Getters and Setter
    public bool IsInteracted { get { return isInteracted; } set { isInteracted = value; } }

    private Material _itemOriginalMaterial;
    protected MeshRenderer _renderer;

    //private variables
    private bool isInteracted;



    // Start is called before the first frame update
    void Start()
    {


    }

    public virtual void Update()
    {
        if (IsInteracted)
        {
            ChangeToInteractMaterial();
        }
        else
        {

            ChangeToOriginalMaterial();
        }

    }

    protected virtual void Initialize()
    {
        _renderer = GetComponent<MeshRenderer>();
        _itemOriginalMaterial = GetComponent<MeshRenderer>().material;
    }

    public virtual void UseItem(GameObject player)
    {
        Debug.Log(player.name + " is using: " + gameObject.name);
    }

    protected virtual void ChangeToInteractMaterial()
    {
        if (_renderer.material == _itemOriginalMaterial)
        {
            _renderer.material = _itemInteractableMaterial;
        }
    }

    protected virtual void ChangeToOriginalMaterial()
    {
        if (_renderer.material != _itemOriginalMaterial)
        {
            _renderer.material = _itemOriginalMaterial;
        }
    }
}
