using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public ObstacleSpawner spawner;
    public Transform playerStart;
    public float restartDelay = 1.0f;

    bool running = false;

    void Start()
    {
        // If no start position assigned, create one automatically
        if (playerStart == null)
        {
            GameObject t = new GameObject("PlayerStart");
            t.transform.position = player.transform.position;
            playerStart = t.transform;
        }

        StartRun();
    }

    public void StartRun()
    {
        spawner.StartSpawning();
        player.ResetPlayer(playerStart.position);
        running = true;
        Debug.Log("Run Started");
    }

    public void EndRun(string reason)
    {
        if (!running) return;

        running = false;
        spawner.StopSpawning();

        Debug.Log("Run Ended: " + reason);

        StartCoroutine(RestartAfterDelay(reason));
    }

    IEnumerator RestartAfterDelay(string reason)
    {
        yield return new WaitForSeconds(restartDelay);

        // When this finishes, TestingBot will handle moving to next run
        TestingBot.Instance?.OnRunEnded(reason);
    }
}
