using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameController gameController;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(gameController.CanLoadNextLevel == true)
        {
            anim.SetBool("canLoadLevel", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameController.CanLoadNextLevel == true)
        {
            levelManager.LoadNextLevel();
        }
    }
}
