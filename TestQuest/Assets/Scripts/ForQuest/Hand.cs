using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Eye _eye;
    [SerializeField] private DisplayInventory _display;
    [SerializeField] private Inventory _inventory;
    public delegate void HandItem(GameObject item);
    public event HandItem ItemInHand;
    private GameObject _handHold;
    private GameObject _item;

    private void Start()
    {
        _eye.ISeeHint += GetHintableObject;
        _inventory.SelectedItem += SetItemObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _item != null)
        {
            if (_item.TryGetComponent(out IActivatableByItem<GameObject> itemActivableByGameobject) && _handHold != null)
            {
                if(itemActivableByGameobject.Activate(_handHold))
                {
                    _inventory.RemoveFromInventory(_handHold);
                    Destroy(_handHold.gameObject);
                }
                ItemInHand.Invoke(null);
                _handHold = null;
            }
            else if (_item.TryGetComponent(out IActivatable itemActivable))
            {
                itemActivable.Activate();
            }
            else if (_item.TryGetComponent(out IPickable itemPickable))
            {
                _inventory.AddToInventory(_item);
            }
        }
        if (Input.GetKeyDown(KeyCode.G) && _handHold != null)
        {
            _inventory.RemoveFromInventory(_handHold);
            ItemInHand.Invoke(null);
            _handHold = null;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _display.ShowInventory();
        }
    }

    private void GetHintableObject(GameObject item)
    {
        if (item != null)
            _item = item;
        else
            _item = null;
    }

    private void SetItemObject(GameObject item)
    {
        if (item != null)
        {
            _handHold = item;
            ItemInHand.Invoke(item);
        }
        else
            _handHold = null;
    }

}
