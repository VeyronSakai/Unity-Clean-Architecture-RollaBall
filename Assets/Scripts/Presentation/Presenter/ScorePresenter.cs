using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Domain.UseCase;

namespace Presentation.Presenter
{
    public class ScorePresenter : IScorePresenter
    {
        [Inject] private IScoreView scoreView;

        public void UpdateScore(int num)
        {
            scoreView.UpdateScore(num);
        }
    }
}

