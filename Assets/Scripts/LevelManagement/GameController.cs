using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int progressAmount;
    public Slider progressSlider;
    public bool CanLoadNextLevel {  get; private set; }

    private void Awake()
    {
        progressAmount = 0;
        CanLoadNextLevel = false;
        progressSlider.value = 0;
        SoulPiece.OnSoulCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 3)
        {
            // Level Is Complete
            Debug.Log("canLoadLevel");
            CanLoadNextLevel = true;
        }
    }
}
