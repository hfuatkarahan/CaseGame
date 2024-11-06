using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boy : MonoBehaviour
{
    [SerializeField] private Transform uiCoinIcon;
    [SerializeField] private GameObject _coin;
    Vector3 _startPosition, _startRotation;
    PlayerController _playerController;
    ScoreManager _scoreManager;
    UIManager _uiManager;

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
    }

    private void Update()
    {
        FallReturn();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            RectTransform uiCoinRect = uiCoinIcon.GetComponent<RectTransform>();
            _coin.transform.DOMove(uiCoinRect.position, 10f).SetEase(Ease.InOutQuad);
            _scoreManager.coinCount += 5;
            _uiManager.coinCountText.text = _scoreManager.coinCount.ToString();
            StartCoroutine(WaitCoin(11));
            //other.gameObject.SetActive(false);
            
        }

        if (other.CompareTag("Finish"))
        {
            _playerController.speed = 0;
            GameManager.Instance.isGameOver = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _startPosition;
        }
    }

    IEnumerator WaitCoin(float delay)
    {
        yield return new WaitForSeconds(delay);
        
    }

    public void FallReturn()
    {
        if (transform.position.y < -7f)
        {
            transform.position = _startPosition;
            transform.eulerAngles = _startRotation;
        }
    }
}
