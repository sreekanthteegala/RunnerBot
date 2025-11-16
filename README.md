# 📌 RunnerQA Bot – Automated Game Testing System (Unity + C#)

## 🎮 Project Overview

**RunnerQA Bot** is an automated gameplay testing system built in Unity.  
It simulates real **Quality Assurance (QA)** processes used in game studios by:

- Automatically playing a simple 3D runner game  
- Detecting obstacles using raycasts  
- Jumping at accurate timings  
- Tracking FPS and performance  
- Detecting timeouts and softlocks  
- Logging gameplay metrics  
- Exporting structured CSV test reports  
- Restarting test runs without human input  

This project demonstrates **automation, bug detection, data logging, and QA workflows**, all of which are key skills for a **Quality Analyst Intern at EA**.

---

## 🧠 Features

- Fully automated test cycles  
- Predictive obstacle detection using raycasts  
- Automatic jump logic  
- Collision and break-state detection  
- Timeout & softlock detection  
- FPS monitoring and average FPS calculation  
- CSV logging to `persistentDataPath`  
- Configurable number of runs  
- Clean modular C# code architecture  

---

## 🗂 Project Structure

```
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
```

---

## 📊 Sample CSV Output

```
Run, Jumps, Collisions, Duration, AvgFPS
1, 3, 1, 2.35, 74.88
2, 4, 0, 3.12, 76.20
```

This data helps analyze:
- Bot accuracy  
- Collision frequency  
- Performance stability  
- Run duration  

---

## 🧪 How to Run the Automated Tests

1. Open the scene:  
   `Assets → Scenes → RunnerScene.unity`

2. Press **Play** in the Unity Editor.

3. The TestingBot will automatically:
   - Play the game  
   - Jump over obstacles  
   - Restart after each run  
   - Generate CSV logs  

---

## 🛠 Technologies Used

- Unity (3D Core)
- C#
- Unity Physics & Raycasting
- Unity Coroutines
- CSV File Logging

---

## 👤 Author

**Teegala Sreekanth**  
Email: ryker034@gmail.com  

---

