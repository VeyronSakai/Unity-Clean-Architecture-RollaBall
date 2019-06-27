using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Domain.Entity;
using UniRx;

namespace Domain.UseCase
{
    public class UpdateScoreUseCase : IUpdateScoreUseCase, IInitializable
    {
        [Inject] private IScorePresenter scorePresenter;
        [Inject] private IScoreEntity scoreEntity;

        void IInitializable.Initialize()
        {
            scoreEntity
                .ScoreProperty
                .Subscribe(score => scorePresenter.UpdateScore(score));
        }
    }

    public interface IUpdateScoreUseCase
    {

    }

}

