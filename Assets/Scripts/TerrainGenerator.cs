using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform spawnPoint;
    public Vector2 endPosition;
    public float spawnTime = 1.5f;

    void Start()
    {
        StartCoroutine(TerrainGen());
    }

    private IEnumerator TerrainGen()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void Spawn()
    {
        if (prefabs.Length == 0)
        {
            return;
        }

        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        var point = spawnPoint;
        var go = Instantiate(prefab, point.position, Quaternion.identity);
        var move = go.GetComponent<SimpleMove2D>();
        if (move != null)
        {
            move = go.AddComponent<SimpleMove2D>();
            move.destiny = endPosition;
        }
    }
}
