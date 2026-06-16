using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    [Header("UI References")]
    public GameObject inventoryPanel;
    public InventoryUI inventoryUI; 

    private bool isInventoryOpen = false;

    private void Start()
    {
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
        isInventoryOpen = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (inventoryPanel == null) return;

        isInventoryOpen = !isInventoryOpen;

        inventoryPanel.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            Time.timeScale = 0f;

            if (inventoryUI != null)
            {
                inventoryUI.Refresh();
            }

            Debug.Log("인벤토리 열림 - 게임 일시정지");
        }
        else
        {
            Time.timeScale = 1f;

            Debug.Log("인벤토리 닫힘 - 게임 재개");
        }
    }
}