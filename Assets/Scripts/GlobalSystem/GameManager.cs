using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent OnGameStart;
    bool gameStarted = false;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();

        EvaluateStartGame();
    }

    private void EvaluateStartGame()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                OnGameStart.Invoke();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
