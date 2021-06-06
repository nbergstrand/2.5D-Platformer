using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("");

            return _instance;
        }
    }
    #endregion

    [SerializeField]
    Text _scoreText;

    [SerializeField]
    Text _livesText;

    private void Start()
    {
        GameManager.OnScoreUIChange += UpdateScoreUI;
        Player.OnLivesChange += UpdateLivesUI;
    }

    void UpdateScoreUI(int score)
    {
        _scoreText.text = "Score: " + GameManager.Instance.CurrentScore;
        
    }

    private void UpdateLivesUI(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }
}
