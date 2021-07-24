using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonController : MonoBehaviour
{
    public Button restartButton;

    public Transform hidePositionPlaceholder;
    public Transform showPositionPlaceholder;

    public void Start()
    {
        restartButton.onClick.AddListener(() => GameManager.get.RestartGame());

        restartButton.transform.position = hidePositionPlaceholder.transform.position;
        GameManager.get.OnGameStart.AddListener(()=> transform.MoveTo(showPositionPlaceholder,0.3f));
    }

}
