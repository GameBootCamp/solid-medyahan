using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishState : MonoBehaviour
{
    [SerializeField] private GameObject finishScreen;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Text successText;

    [SerializeField] private GameObject player;

    public bool isFinishScreen;

    private void Start()
    {
        isFinishScreen = true;
        finishScreen.SetActive(true);
        playAgainButton.onClick.AddListener(PlayAgain);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isFinishScreen = false;
            finishScreen.SetActive(false);
            gameObject.SetActive(false);
            PlayAgain();
        }

        if (player.activeInHierarchy == true)
            successText.text = "YOU WIN!";
        else
            successText.text = "GAME OVER!";


    }
    private void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
