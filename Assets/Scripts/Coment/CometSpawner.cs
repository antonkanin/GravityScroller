using System.Collections;
using UnityEngine;

public class CometSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cometPrefab = default;

    [SerializeField] private float spawnPositionX = default;

    private void OnEnable()
    {
        StartCoroutine(Co_SpawnComent());
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