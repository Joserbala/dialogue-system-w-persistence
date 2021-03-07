using UnityEngine;
using TMPro;
using Joserbala.Serialization;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;

namespace Joserbala.UI
{
    public class WelcomePrompt : MonoBehaviour
    {
        [SerializeField] private float timeStatic;
        [SerializeField] private float timeToFade;
        [TextArea(3, 10)]
        [Tooltip("Prompt to be displayed at the welcome, end it without spaces.")]
        [SerializeField] private string welcomePrompt = "This game creates a folder in your MyDocuments folder.\n\nYou can find this folder at";
        [SerializeField] private TextMeshProUGUI initialText;
        [SerializeField] private UnityEvent startGame;

        private Sequence fadeOut;

        private void Awake()
        {
            CreateFadeOutSequence();
        }

        private void Start()
        {
            StartCoroutine(StartFading());
            initialText.text = welcomePrompt + " " + FileManager.SavePath + ".";
        }

        IEnumerator StartFading()
        {
            yield return new WaitForSeconds(timeStatic);
            fadeOut.Play();
        }

        private void CreateFadeOutSequence()
        {
            fadeOut = DOTween.Sequence();

            fadeOut.Append(initialText.DOFade(0, timeToFade));
            fadeOut.AppendCallback(() => gameObject.SetActive(false));
            fadeOut.AppendCallback(() => startGame?.Invoke());
        }
    }
}