using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;
    private GameManager instance;
    public int difficulty;

    private void Start()
    {
        instance = GameManager.instance;
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        instance.StartGame(difficulty);
    }
}
