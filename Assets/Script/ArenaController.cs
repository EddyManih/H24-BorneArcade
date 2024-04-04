using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArenaController : MonoBehaviour
{
    PlayerController[] playerControllers;
    [SerializeField] GameObject endMenu;
    [SerializeField] GameObject replayButton;

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
        StartCoroutine(EndGameCoroutine());
    }

    IEnumerator EndGameCoroutine()
    {
        foreach (PlayerController playerController in playerControllers)
        {
            if (playerController) playerController.DisableMovement();
        }

        foreach (GameObject input in GameObject.FindGameObjectsWithTag("Input"))
        {
            input.SetActive(false);
        }

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
