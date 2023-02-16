using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private int _difficulty;

    private Button _button;
    private GameManager _gameManager;

    void Start()
    {
        _button = GetComponent<Button>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(_difficulty);
    }
}
