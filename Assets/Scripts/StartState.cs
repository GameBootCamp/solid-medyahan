using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartState : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameplayState;
    [SerializeField] private Text startText;

    private GameObject player;
    private Coroutine coroutine;

    public bool isStartScreen;

    public void Start()
    {
        isStartScreen = true;
        startScreen.SetActive(true);

        player = GameObject.FindWithTag("player");
        player.GetComponent<PlayerController>().enabled = false;
        coroutine = StartCoroutine(WaitForStart());
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isStartScreen = false;
            StopCoroutine(coroutine);
            startScreen.SetActive(false);

            player.GetComponent<PlayerController>().enabled = true;

            gameplayState.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator WaitForStart()
    {
        float a = 0;

        while (isStartScreen)
        {
            var val = Mathf.PingPong(a, 0.5f) + 0.5f;
            startText.color = new Color(1, 1, 1, val);
            yield return null;
            a += Time.deltaTime;
        }
    }
}
