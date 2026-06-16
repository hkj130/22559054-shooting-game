using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DropItem : MonoBehaviour
{
    public ItemData itemData;
    public int count = 1;

    private void Reset()
    {
        GetComponent<Collider>().isTrigger = true;
    }
}
