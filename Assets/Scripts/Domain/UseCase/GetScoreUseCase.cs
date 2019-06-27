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
            // for文を使うと何故かエラーになってしまう
            blockPresenter.OnTriggerEnterPlayerAsObservable(0).Subscribe(_ => blockPresenter.BlockList[0].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(1).Subscribe(_ => blockPresenter.BlockList[1].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(2).Subscribe(_ => blockPresenter.BlockList[2].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(3).Subscribe(_ => blockPresenter.BlockList[3].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(4).Subscribe(_ => blockPresenter.BlockList[4].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(5).Subscribe(_ => blockPresenter.BlockList[5].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(6).Subscribe(_ => blockPresenter.BlockList[6].DestroyBlock());
            blockPresenter.OnTriggerEnterPlayerAsObservable(7).Subscribe(_ => blockPresenter.BlockList[7].DestroyBlock());

        }
    }

    public interface IGetScoreUseCase
    {

    }
}