using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public Controls Controls;
    [SerializeField] GameObject Win;
    [SerializeField] GameObject Loss;

    [Header("Canvas Text")]

    [SerializeField] TextMeshProUGUI WinText;
    [SerializeField] TextMeshProUGUI LossText;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    private void Awake()
    {
        Inst();
    }

    private void Inst()
    {
        Win.SetActive(false);
        Loss.SetActive(false);
        Time.timeScale = 1;
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!");
        SetLossCanvas();


    }

    public void OnPlayerReachFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You Won!");
        SetWinCanvas();
    }

    public void SetWinCanvas()
    {
        Win.SetActive(true);
        WinText.text = "You Win!";
        Time.timeScale = 1;
    }

    public void SetLossCanvas()
    {
        Loss.SetActive(true);
        LossText.text = "You Loss!";
        Time.timeScale = 0;
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0); 
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
