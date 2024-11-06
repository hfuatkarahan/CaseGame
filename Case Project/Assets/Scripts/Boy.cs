using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boy : MonoBehaviour
{
    [SerializeField] private Transform uiCoinIcon;
    [SerializeField] private GameObject _paintBoy;
    [SerializeField] private Camera _dummyCam;

    public GameObject _drawingCanvas, _mainCamera, _drawingCamera;

    Vector3 _startPosition, _startRotation;
    PlayerController _playerController;
    ScoreManager _scoreManager;
    UIManager _uiManager;
    GameObject _canvas;
    

    private void Awake()
    {
        _scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        _uiManager = GameObject.Find("Game Manager").GetComponent<UIManager>();
        
    }

    private void Start()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _startRotation = new Vector3(0,0,0);
        _playerController = GetComponent<PlayerController>();
        _canvas = GameObject.Find("Canvas");
    }

    private void Update()
    {
        FallReturn();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _scoreManager.coinCount += 5;
            _uiManager.coinCountText.text = _scoreManager.coinCount.ToString();
            
        }

        if (other.CompareTag("Finish"))
        {
            _playerController.speed = 0;
            GameManager.Instance.isGameOver = true;
            _canvas.SetActive(false);
            _drawingCanvas.SetActive(true);
            _mainCamera.gameObject.SetActive(false);
            _dummyCam.gameObject.SetActive(true);
            _drawingCamera.gameObject.SetActive(true);
            _paintBoy.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _startPosition;
            _scoreManager.UpdateDeadScore();
        }
    }


    public void FallReturn()
    {
        if (transform.position.y < -7f)
        {
            transform.position = _startPosition;
            transform.eulerAngles = _startRotation;
            _scoreManager.UpdateDeadScore();
        }
    }
}
