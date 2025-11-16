📌 RunnerQA Bot – Automated Game Testing System (Unity + C#)
🎮 Project Overview

RunnerQA Bot is an automated gameplay testing system built in Unity.
It simulates Quality Assurance processes used in real game studios by:

Automatically playing a simple 3D runner game

Detecting obstacles using raycasts

Jumping at the correct time

Tracking FPS and performance

Detecting timeouts and softlocks

Logging gameplay metrics

Exporting CSV test reports

Restarting the game without human input

This project demonstrates automation, bug detection, data logging, and QA workflows, all of which are key requirements for a Quality Analyst Intern at EA.

🧠 Features

✔ Fully automated test cycles
✔ Predictive obstacle detection via raycasts
✔ Automatic jumping logic
✔ Collision/break-state detection
✔ Timeout/softlock detection
✔ FPS monitoring and average FPS calculation
✔ CSV logging to persistentDataPath
✔ Configurable number of runs
✔ Modular scripts with clean architecture

🗂 Project Structure
Assets/
  Scripts/
    Player/
      PlayerController.cs
    Obstacles/
      ObstacleSpawner.cs
    Managers/
      GameManager.cs
      Logger.cs
    TestingBot/
      TestingBot.cs
  Prefabs/
    Obstacle.prefab
  Scenes/
    RunnerScene.unity

📊 Sample CSV Output
Run, Jumps, Collisions, Duration, AvgFPS
1, 3, 1, 2.35, 74.88
2, 4, 0, 3.12, 76.20

🧪 How to Run Tests

Open RunnerScene.unity

Press Play

Watch the bot:

Play the game

Jump automatically

Restart after each run
