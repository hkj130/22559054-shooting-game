using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public InventorySlotUI[] bagSlots;
    public InventorySlotUI[] equipSlots;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void Toggle()
    {
    }

    public void Refresh()
    {
    }
}
