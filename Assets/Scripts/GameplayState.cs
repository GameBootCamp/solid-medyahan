using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayState : MonoBehaviour
{
    public int currentCheckpoint;
    public int totalCheckpoint;

    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private GameObject finishState;
    [SerializeField] private GameObject player;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button playAgainButton;

    public bool isGameplayScreen;

    private void Start()
    {
        isGameplayScreen = true;
        gameplayScreen.SetActive(true);
    }

    private void Update()
    {
        if(player.activeInHierarchy == false)
        {
            isGameplayScreen = false;
            gameplayScreen.SetActive(false);
            finishState.SetActive(true);
            gameObject.SetActive(false);
        }

        if(gameManager.isComplete)
        {
            playAgainButton.gameObject.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
        }

    }

    public void PlayAgain()
    {
        playAgainButton.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        SceneManager.LoadScene(0);
    }
}

