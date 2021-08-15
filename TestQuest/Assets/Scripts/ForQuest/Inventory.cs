using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int _inventorySize;
    [SerializeField] private GameObject _player;
    private List<GameObject> _items;
    public delegate void Selected(GameObject item);
    public event Selected SelectedItem;
    public delegate void UpdateStatus();
    public event UpdateStatus StatusUpdate;

    public GameObject this[int index] 
    {
        get
        {
            return _items[index];
        }
        set
        {
            _items[index] = value;
        }
    }
    public int Count
    {
        get
        {
            return _items.Count;
        }
    }

    private void Start()
    {
        _items = new List<GameObject> ();
    }

    public void AddToInventory(GameObject item)
    {
        if (_items.Count < _inventorySize)
        {
            _items.Add(item);
            item.transform.position = transform.position;
            StatusUpdate.Invoke();
        }
    }

    public void RemoveFromInventory(GameObject item)
    {
        _items.Remove(item);
        StatusUpdate.Invoke();
        item.transform.position = _player.transform.position;
    }

    public void Selectitem(int i)
    {
        if (i<_items.Count)
            SelectedItem.Invoke(_items[i]);
    }
    public void CheckInventory()
    {
        foreach(GameObject i in _items)
        {
            Debug.Log(null);

            if (i.gameObject==null)
            {
                Debug.Log(null);
            }
        }
    }
}
