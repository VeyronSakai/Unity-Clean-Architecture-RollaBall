using UnityEngine;
using Zenject;
using Domain.Entity;
using UniRx;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Domain.UseCase
{
    public class GetScoreUseCase : IGetScoreUseCase, IInitializable
    {
        [Inject] IBlockPresenter blockPresenter;
        [Inject] IScoreEntity scoreEntity;

        void IInitializable.Initialize()
        {
            // ブロックに衝突した時の処理

            // for文ではなくLINQを使うと何故か上手くいく
            Enumerable
                .Range(0, blockPresenter.BlockList.Count)
                .ToList()
                .ForEach(i => PlayerEnterBlockTrigger(i));

            //// このようにfor文で書き直すと何故かエラーになる
            //for(int i = 0; i < blockPresenter.BlockList.Count; i++)
            //{
            //    blockPresenter.BlockList[i].DestroyBlock();
            //    scoreEntity.Increment();
            //}
        }

        private void PlayerEnterBlockTrigger(int i)
        {
            blockPresenter.OnTriggerEnterPlayerAsObservable(i).Subscribe(_ =>
            {
                blockPresenter.BlockList[i].DestroyBlock();
                scoreEntity.Increment();
            });
        }
    }

    public interface IGetScoreUseCase
    {

    }
}
