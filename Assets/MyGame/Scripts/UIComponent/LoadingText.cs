using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace MyGame.UIComponent
{
    [RequireComponent(typeof(TMP_Text))]
    public class LoadingText : MonoBehaviour
    {
        private TMP_Text _loadingText;

        private void Awake()
        {
            _loadingText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            StartCoroutine(UpdateLoadingText());
        }

        private IEnumerator UpdateLoadingText()
        {
            string[] loadingTexts = new string[]
            {
                "Loading",
                "Loading.",
                "Loading..",
                "Loading...",
            };
            int currentIndex = 0;

            while (true)
            {
                _loadingText.text = loadingTexts[currentIndex];

                currentIndex += 1;
                if (currentIndex >= loadingTexts.Count())
                {
                    currentIndex = 0;
                }

                yield return new WaitForSeconds(0.66f);
            }
        }
    }
}
