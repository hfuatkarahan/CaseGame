using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinTween : MonoBehaviour
{

    [SerializeField] private Transform uiCoinIcon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boy"))
        {
            //Vector3 targetPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, uiCoinIcon.rectTransform.position);
            RectTransform uiCoinRect = uiCoinIcon.GetComponent<RectTransform>();
            transform.DOMove(uiCoinRect.position, 10f).SetEase(Ease.InOutQuad);
            //transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InBack);

        }
    }
}
