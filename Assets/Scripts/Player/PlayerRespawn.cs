using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //[SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location

        ////Move the camera to the checkpoint's room
        //Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    //// Activate Checkpoints
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Checkpoint")
    //    {
    //        currentCheckpoint = collision.transform;
    //        //SoundManager.instance.PlaySound(checkpoint);
    //        collision.GetComponent<Collider2D>().enabled = false;
    //        collision.GetComponent<Animator>().SetTrigger("activate");
    //    }
    //}

    //activate checkpoints
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Spawnpoint")
        {
            currentCheckpoint = collision.transform;                    // Store activated checkpoint as current checkpoint
            collision.GetComponent<Collider2D>().enabled = false;       // Makes it so you can't reactivate the same checkpoint over and over
        }
        else if (collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;                    // Store activated checkpoint as current checkpoint
            //SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;       // Makes it so you can't reactivate the same checkpoint over and over
            collision.GetComponent<Animator>().SetTrigger("activate");  // Triggers appear checkpoint animation
        }
    }
}