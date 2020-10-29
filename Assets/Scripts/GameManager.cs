using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private Slider bar;
    [SerializeField] private GameObject[] finishParticles;
    [SerializeField] private GameObject startState;
    [SerializeField] private GameplayState gameplayState;

    [SerializeField] private Text winText;

    public bool isComplete;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static GameManager Instance()
    {
        return instance;
    }

    private void Start()
    {
        PrepareGame();
    }

    private void PrepareGame()
    {
        isComplete = false;

        startState.SetActive(true);
        
        gameplayState.totalCheckpoint = 10;
        ChangeProgressValue();
    }

    public void ChangeCheckPoint(int id)
    {
        gameplayState.currentCheckpoint = id + 1;
        if (id + 1 == gameplayState.totalCheckpoint)
        {
            CompleteLevel();
        }
        ChangeProgressValue();
    }

    public void ChangeProgressValue()
    {
        float progressValue = (float)gameplayState.currentCheckpoint / (float)gameplayState.totalCheckpoint;
        bar.value = progressValue;
    }

    private void CompleteLevel()
    {
        isComplete = true;

        winText.text = "CONGURATULATIONS!";
        foreach (var item in finishParticles)
        {
            item.gameObject.SetActive(true);
        }

    }
}
