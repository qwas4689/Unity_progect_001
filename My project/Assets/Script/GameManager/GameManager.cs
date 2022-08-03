using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public bool IsGameOver { get; private set; }

    public void EndGame()
    {
        IsGameOver = true;

        UIManager.instance.SetActiveGameoverUI(true);
    }

    public void PlayGame()
    {
        IsGameOver = false;

        UIManager.instance.SetActiveGameoverUI(false);
    }
}
