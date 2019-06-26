using System;
using System.Collections.Generic;
using UnityEngine;
using Domain.UseCase;
using Zenject;
using UniRx;
using UniRx.Triggers;

namespace Presentation.Presenter
{
    public class BlockPresenter : IBlockPresenter
    {
        [Inject] private IFactory<Vector3, IBlockView> blockViewFactory;

        private List<IBlockView> blockList = new List<IBlockView>();

        public void InstantiateBlock(Vector3 pos)
        {
            blockList.Add(blockViewFactory.Create(pos));
        }

        public IObservable<Unit> OnTriggerEnterPlayerAsObservable(int i)
        {
            return blockList[i].OnTriggerEnterPlayerAsObservable();
        }
    }
}