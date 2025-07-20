using System;
using UnityEngine;

public class SoulPiece : MonoBehaviour, IItem
{
    [SerializeField] private int worth;
    public static event Action<int> OnSoulCollect;
    private bool collected = false;

    public void Collect()
    {
        if (!collected)
        {
            collected = true;
            Debug.Log(worth);
            OnSoulCollect?.Invoke(worth);
            Destroy(gameObject);
        }
    }
}
