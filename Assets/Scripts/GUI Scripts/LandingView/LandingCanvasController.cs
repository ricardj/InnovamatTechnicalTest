using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandingCanvasController : MonoBehaviour
{
    public Text titleText;
    public Text subtitleText;

    public Transform hidePositionTitle;
    public Transform hidePositionSubtitle;

    public void Start()
    {
        GameManager.get.OnGameStart.AddListener(() =>
        {
            titleText.transform.MoveTo(hidePositionTitle, 0.3f);
            subtitleText.transform.MoveTo(hidePositionSubtitle, 0.3f);
        });

    }
}
