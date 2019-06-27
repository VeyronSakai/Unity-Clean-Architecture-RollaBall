using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Presentation.Presenter
{
    public class ScorePresenter
    {
        [Inject] private IScoreView scoreView;

        public void UpdateScore(int num)
        {
            scoreView.UpdateScore(num);
        }
    }
}

