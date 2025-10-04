using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] prefabs;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    [Header("Spawn Cooldown")]
    public float spawnTime = 1.5f;

    [Header("Destination")]
    public Vector2 endPosition = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void Spawn()
    {
        if (prefabs.Length == 0 || spawnPoints.Length == 0)
        {
            return;
        }

        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var go = Instantiate(prefab, point.position, Quaternion.identity);
        var move = go.GetComponent<SimpleMove2D>();
        if (move == null)
        {
            move = go.AddComponent<SimpleMove2D>();
            move.destiny = endPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
