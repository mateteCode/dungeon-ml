using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] DungeonGenerator generator;
    [SerializeField] GameObject player;
    public event Action OnPlayerShowed;
    GameState _gameState;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else Destroy(gameObject);
        _gameState = GameState.GENERATING;
    }

    private void OnEnable()
    {
        generator.OnMazeCreated += ShowPlayer;
    }

    private void OnDisable()
    {
        generator.OnMazeCreated -= ShowPlayer;
    }

    void Start()
    {
        generator = generator.GetComponent<DungeonGenerator>();
        generator?.MazeGenerator();
    }
       
    public void ShowPlayer(Vector3 position)
    {
        Instantiate(player, position, Quaternion.identity);
        OnPlayerShowed?.Invoke();
    }

    private void OnGUI()
    {
        float w = Screen.width / 2;
        float h = Screen.height - 80;
        switch(_gameState)
        {
            case GameState.GENERATING:
                if (GUI.Button(new Rect(w, h, 250, 50), "Regenerate Dungeon"))
                {
                    RegenerateDungeon();
                }
                if (GUI.Button(new Rect(w/2, h, 250, 50), "Play"))
                {
                    _gameState = GameState.PLAYING;
                    Play();
                }
                break;
            case GameState.PLAYING:
                if (GUI.Button(new Rect(w / 2, h, 250, 50), "Return to Main Menu"))
                {
                    _gameState = GameState.GENERATING;
                }
                break;
        }

    }

    void RegenerateDungeon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Play()
    {

    }
}
