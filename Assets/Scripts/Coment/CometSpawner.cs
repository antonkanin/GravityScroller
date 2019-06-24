using System.Collections;
using System.Threading;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cometPrefab = default;

    [SerializeField] private float spawnPositionX = default;

    private Coroutine spawnCoroutine;

    public void EnableSpawn()
    {
        spawnCoroutine = StartCoroutine(Co_SpawnComent());
    }

    public void DisableSpawn()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private IEnumerator Co_SpawnComent()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            SpawnComment();
        }
    }

    private void SpawnComment()
    {
        var posY = Random.Range(-3f, 3f);
        var cometObject = Instantiate(cometPrefab, new Vector2(spawnPositionX, posY), Quaternion.identity);
        Destroy(cometObject, 5f);
    }
}