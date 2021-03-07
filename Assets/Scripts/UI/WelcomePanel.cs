using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections;

namespace Joserbala.UI
{
    public class WelcomePanel : MonoBehaviour
    {
        [SerializeField] private float timeStatic;
        [SerializeField] private float timeToFade;
        [SerializeField] private Image panel;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private UnityEvent startGame;

        private Sequence fadeOut;

        private void Awake()
        {
            CreateFadeOutSequence();
        }

        private void Start()
        {
            StartCoroutine(StartFading());
        }

        IEnumerator StartFading()
        {
            yield return new WaitForSeconds(timeStatic);
            fadeOut.Play();
        }

        private void CreateFadeOutSequence()
        {
            fadeOut = DOTween.Sequence();

            fadeOut.Append(panel.DOFade(0, timeToFade));
            fadeOut.Join(text.DOFade(0, timeToFade));
            fadeOut.AppendCallback(() => gameObject.SetActive(false));
            fadeOut.AppendCallback(() => startGame?.Invoke());
        }
    }
}