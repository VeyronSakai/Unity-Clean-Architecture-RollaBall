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
            blockPresenter.OnTriggerEnterPlayerAsObservable(0).Subscribe(_ => {
                blockPresenter.BlockList[0].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(1).Subscribe(_ => {
                blockPresenter.BlockList[1].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(2).Subscribe(_ => {
                blockPresenter.BlockList[2].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(3).Subscribe(_ => {
                blockPresenter.BlockList[3].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(4).Subscribe(_ => {
                blockPresenter.BlockList[4].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(5).Subscribe(_ => {
                blockPresenter.BlockList[5].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(6).Subscribe(_ => {
                blockPresenter.BlockList[6].DestroyBlock();
                scoreEntity.Increment();
                });
            blockPresenter.OnTriggerEnterPlayerAsObservable(7).Subscribe(_ => {
                blockPresenter.BlockList[7].DestroyBlock();
                scoreEntity.Increment();
                });
        }
    }

    public interface IGetScoreUseCase
    {

    }
}
