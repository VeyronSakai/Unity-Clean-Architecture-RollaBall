using UnityEngine;
using Zenject;
using Domain.Entity;
using UniRx;

namespace Domain.UseCase
{
    public class GetScoreUseCase : IGetScoreUseCase, IInitializable
    {
        [Inject] IBlockPresenter blockPresenter;
        [Inject] IScoreEntity scoreEntity;

        void IInitializable.Initialize()
        {

        }
    }

    public interface IGetScoreUseCase
    {

    }
}