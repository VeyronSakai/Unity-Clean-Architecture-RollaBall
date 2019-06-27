using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Presentation.Presenter;
using TMPro;

namespace Presentation.View
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        private TextMeshProUGUI textMeshPro;

        private void Start()
        {
            textMeshPro = this.GetComponent<TextMeshProUGUI>();
        }

        public void UpdateScore(int num)
        {
            textMeshPro.text = num.ToString();
        }
    }
}