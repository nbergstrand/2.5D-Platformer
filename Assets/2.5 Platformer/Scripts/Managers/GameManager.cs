using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Failed to acccess GameManager");

            return _instance;
        }
    
    }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(this);
    }
    #endregion
    public static Action<int> OnScoreUIChange;

    public int CurrentScore { get; private set; }

    public Vector3 StartPosition { get; private set; }

    public void UpdateScore(int score)
    {
        CurrentScore += score;
        OnScoreUIChange(CurrentScore);
    }

    public void SetStartPosition(Vector3 position)
    {
        StartPosition = position;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}
