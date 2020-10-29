using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public CheckpointManager checkpointManager;

    [SerializeField] private CheckpointData checkpointData;

    [SerializeField] private Material[] checkpointMaterials;

    public bool isMyTurn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (isMyTurn)
            {
                isMyTurn = false;
                checkpointData.isPassed = true;
                ChangeColor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if (checkpointData.isPassed)
            {
                checkpointManager.SetLastPassedCheckPoint(checkpointData.checkpointID);
            }
        }
    }

    public void ResetCheckPoint()
    {
        checkpointData.isPassed = false;
        ChangeColor();
    }

    private void ChangeColor()
    {
        checkpointData.checkpointRenderer.material = checkpointMaterials[(checkpointData.isPassed ? 0 : 1)];
    }

    
}

[System.Serializable]
public class CheckpointData
{
    public int checkpointID;
    public bool isPassed;
    public Renderer checkpointRenderer;
}