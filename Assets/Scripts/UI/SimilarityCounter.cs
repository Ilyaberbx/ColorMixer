using System.Collections;
using TMPro;
using UnityEngine;


namespace ColorMixer.UI
{
    public class SimilarityCounter
    {
        private float _countingRate;
        private int _similarityPercent;

        public SimilarityCounter(float coutingRate) => _countingRate = coutingRate;

        public void SetSimilarity(int percent) => _similarityPercent = percent;
        public IEnumerator ShowSimilarityRoutine(TextMeshProUGUI text)
        {
            for (int i = 0; i <= _similarityPercent; i++)
            {
                text.text = "Liquid Similarity: " + i + "%";
                yield return new WaitForSeconds(_countingRate);
            }
        }
    }
}
