using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    Text _scoreText;

    [SerializeField]
    Text _livesText;

    private void Start()
    {
        GameManager.OnScoreUIChange += UpdateScoreUI;
        Player.OnLivesChange += UpdateLivesUI;
    }

    private void OnDisable()
    {
        GameManager.OnScoreUIChange -= UpdateScoreUI;
        Player.OnLivesChange -= UpdateLivesUI;
    }

    void UpdateScoreUI(int score)
    {
        _scoreText.text = "Score: " + GameManager.Instance.CurrentScore;
        
    }

    private void UpdateLivesUI(int lives)
    {
        if(_livesText != null)
            _livesText.text = "Lives: " + lives;
    }
}
