using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] DungeonGenerator generator;
    [SerializeField] GameObject _playerPrefab;
    public event Action OnPlayerShowed;
    GameState _gameState;
    public GameState GameState => _gameState;
    GameObject _player;
    CameraController _mainCameraController;

    GUIStyle _buttonStyle;

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
        _mainCameraController = Camera.main.gameObject.GetComponent<CameraController>();
       generator = generator.GetComponent<DungeonGenerator>();
        generator?.MazeGenerator();
        
    }
       
    public void ShowPlayer(Vector3 position)
    {
        _mainCameraController.TargetToMaze();
        _player = Instantiate(_playerPrefab, position, Quaternion.identity);
    }

    private void OnGUI()
    {
        if(_buttonStyle == null)
        {
            _buttonStyle = new GUIStyle(GUI.skin.button);
            _buttonStyle.fontSize = 24;
        }

        float w = Screen.width / 2;
        float h = Screen.height - 120;
        switch(_gameState)
        {
            case GameState.GENERATING:
                if (GUI.Button(new Rect(w, h, 400, 80), "Regenerate Dungeon", _buttonStyle))
                {
                    RegenerateDungeon();
                }
                if (GUI.Button(new Rect(w/2, h, 400, 80), "Play", _buttonStyle))
                {
                    _gameState = GameState.PLAYING;
                    Play();
                }
                break;
            case GameState.PLAYING:
                if (GUI.Button(new Rect(w / 2, h, 400, 80), "Return to Main Menu", _buttonStyle))
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
        _mainCameraController.TargetToPlayer();
        GameObject [] checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        foreach(GameObject checkPoint in checkPoints) Destroy(checkPoint);
    }

}
