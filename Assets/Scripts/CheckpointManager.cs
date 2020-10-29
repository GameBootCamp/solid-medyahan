//#define TOUR
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

#if TOUR
    private const int TOTAL_TOUR= 1;
    private int tour = 1;
#endif

    [SerializeField] private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private int lastPassedCheckpoint;

    private void Start()
    {
        for (int i = 0; i < checkpoints.Count; i++)
        {
            checkpoints[i].checkpointManager = this;
            if (i == 0) checkpoints[i].isMyTurn = true;
        }
    }

    public void SetLastPassedCheckPoint(int id)
    {
        lastPassedCheckpoint = id;
        GameManager.Instance().ChangeCheckPoint(lastPassedCheckpoint);

        if (checkpoints.Count - 1 > id)
        {
            checkpoints[id + 1].isMyTurn = true;
        }
        else
        {
#if TOUR
            if (tour < TOTAL_TOUR)
            {
                ResetTour();

            }
            else
            {
                EndGame();
            }
           
#else
            EndGame();
#endif
        }
    }


#if TOUR
    public void ResetTour()
    {
        tour++;

        for(int i = 0; i < checkpoints.Count; i++)
        {
            checkpoints[i].ResetCheckPoint();

            if (i == 0)
            {
                checkpoints[i].isMyTurn = true;
            }
            else
            {
                checkpoints[i].isMyTurn = false;
            }
        }
    }

#endif

    private void EndGame()
    {
        Debug.Log("Level Complete");
    }
}
