using UnityEngine;

public class MonsterDropper : MonoBehaviour
{
    [System.Serializable]
    public class DropTable
    {
        public ItemData itemData;
        [Range(0f, 1f)] public float dropRate = 0.5f;
        public int minCount = 1;
        public int maxCount = 1;
    }

    public GameObject dropPrefab;
    public DropTable[] dropTables;

    public void Drop()
    {
        foreach (DropTable table in dropTables)
        {
            if (table == null || table.itemData == null) continue;

            if (Random.value <= table.dropRate)
            {
                int dropCount = Random.Range(table.minCount, table.maxCount + 1);

                GameObject spawnedDrop = Instantiate(dropPrefab, transform.position, Quaternion.identity);

                DropItem dropItemComponent = spawnedDrop.GetComponent<DropItem>();
            }
        }
    }
}
