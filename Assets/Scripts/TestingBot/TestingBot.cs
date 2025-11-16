using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

public class TestingBot : MonoBehaviour
{
    public static TestingBot Instance;

    [Header("References")]
    public PlayerController player;
    public GameManager gameManager;

    [Header("Bot Settings")]
    public int totalRuns = 5;
    public float checkDistance = 8f;
    public float checkInterval = 0.05f;
    public float timeout = 30f;

    int currentRun = 0;
    float runStartTime;

    List<string> csvLines = new List<string>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(TestLoop());
    }

    IEnumerator TestLoop()
    {
        yield return new WaitForSeconds(1f); // Wait for scene to load

        for (currentRun = 1; currentRun <= totalRuns; currentRun++)
        {
            Debug.Log("BOT: Starting run " + currentRun);
            csvLines.Clear();
            runStartTime = Time.time;

            int jumpCount = 0;
            int collisionCount = 0;
            float fpsSum = 0f;
            int fpsCount = 0;

            gameManager.StartRun();

            bool runOver = false;

            while (!runOver)
            {
                // FPS tracking
                fpsSum += 1f / Time.deltaTime;
                fpsCount++;

                // 1. Timeout
                if (Time.time - runStartTime > timeout)
                {
                    EndRun("Timeout");
                    collisionCount++;
                    runOver = true;
                    break;
                }

                // 2. Detect obstacles via raycast
                RaycastHit hit;
                Vector3 origin = player.transform.position + Vector3.up * 0.2f;
                if (Physics.Raycast(origin, Vector3.forward, out hit, checkDistance))
                {
                    if (hit.collider.CompareTag("Obstacle"))
                    {
                        if (player.IsGrounded)
                        {
                            player.Jump();
                            jumpCount++;
                        }
                    }
                }

                // 3. Player died (collision)
                if (!player.IsAlive)
                {
                    EndRun("Collision");
                    collisionCount++;
                    runOver = true;
                    break;
                }

                yield return new WaitForSeconds(checkInterval);
            }

            // Summary row
            float duration = Time.time - runStartTime;
            float avgFPS = fpsSum / fpsCount;

            csvLines.Add($"{currentRun},{jumpCount},{collisionCount},{duration:F2},{avgFPS:F2}");

            // Save CSV
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Run, Jumps, Collisions, Duration, AvgFPS");
            foreach (var line in csvLines) sb.AppendLine(line);

            string fileName = $"RunLog_{DateTime.Now:yyyyMMdd_HHmmss}_Run{currentRun}.csv";
            Logger.WriteCsv(fileName, sb.ToString());

            yield return new WaitForSeconds(1f);
        }

        Debug.Log("BOT: All runs completed.");
    }

    public void OnRunEnded(string reason)
    {
        // Called by GameManager
        Debug.Log("BOT: OnRunEnded — " + reason);
    }

    void EndRun(string reason)
    {
        gameManager.EndRun(reason);
    }
}
