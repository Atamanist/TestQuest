using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Hand _hand;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private Image _selectItem;
    [SerializeField] private Sprite _startSprite;
    [SerializeField] PlayerMouseLock _mouseLock;
    [SerializeField] PlayerKeyboardMove _keyboboardMove;
    private bool _inventoryIsShowing;

    private void Start()
    {
        ShowInventory();
        _inventory.StatusUpdate += SetButtonSprite;
        _hand.ItemInHand += SetItemInHand;
    }

    public void ShowInventory()
    {
        _inventoryIsShowing = !_inventoryIsShowing;
        _inventoryPanel.SetActive(_inventoryIsShowing);
        _mouseLock.Move();
        _keyboboardMove.Move();
        if (_inventoryIsShowing)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetButtonSprite()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            if (i<_inventory.Count)
            {
                _buttons[i].GetComponent<Image>().sprite = _inventory[i].GetComponent<Item>().SpriteItem();
            }
            else
            {
                _buttons[i].GetComponent<Image>().sprite = _startSprite;
            }
        }
    }

    public void SetItemInHand(GameObject item)
    {
        if (item!= null)
        {
            _selectItem.sprite = item.GetComponent<Item>().SpriteItem();
        }
        else
        {
            _selectItem.sprite = _startSprite;
        }
    }
}
