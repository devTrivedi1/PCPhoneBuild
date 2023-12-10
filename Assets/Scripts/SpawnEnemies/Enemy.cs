
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float durationToDisable;
    private void OnEnable()
    {
        Invoke(nameof(DeactivateObject), durationToDisable);
    }

    void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
