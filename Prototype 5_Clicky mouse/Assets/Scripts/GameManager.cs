using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _titleScreen;
    [SerializeField] private int _score;
    [SerializeField] private float _spawnRate;

    public bool _isGameActive;

    private IEnumerator SpawnTarget()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            var index = Random.Range(0, _targets.Count);    
            Instantiate(_targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        _isGameActive = false;  
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        _isGameActive = true;
        _score = 0;
        _spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        _titleScreen.SetActive(false);
    }
}
