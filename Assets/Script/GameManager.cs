using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TextPoints;
    private int score = 0;
    private float timer = 0f;
    private float interval = 2f; 

    private void Update()
    {
        TextPoints.text = "Puntos: " + score;
        UpdatePoints();
    }
    void UpdatePoints()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            score = score + 10;
            timer = 0f;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Mate_S6");
    }
}
