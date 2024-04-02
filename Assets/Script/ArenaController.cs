using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaController : MonoBehaviour
{
    PlayerController[] playerControllers;

    void Start()
    {
        playerControllers = FindObjectsOfType<PlayerController>();

        foreach (PlayerController playerController in playerControllers)
        {
            playerController.healthManagerSO.DiedEvent.AddListener(EndGame);
        }
    }

    void EndGame()
    {
        foreach (PlayerController playerController in playerControllers)
        {
            if (playerController) playerController.DisableMovement();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
