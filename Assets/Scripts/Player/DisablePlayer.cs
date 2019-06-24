using UnityEngine;

public class DisablePlayer : MonoBehaviour
{
    [SerializeField] private GameObject player = default;

    private void Start()
    {
        player.SetActive(false);
    }
}
