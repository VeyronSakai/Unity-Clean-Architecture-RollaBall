using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using Domain.UseCase;

namespace Presentation.Presenter
{
    public class BlockPresenter : IBlockPresenter
    {
        [Inject] private IFactory<Vector3, IBlockView> blockViewFactory;

        public List<IBlockView> BlockList { get; set; } = new List<IBlockView>();

        public void InstantiateBlock(Vector3 pos)
        {
            BlockList.Add(blockViewFactory.Create(pos));
        }

        public IObservable<Unit> OnTriggerEnterPlayerAsObservable(int i)
        {
            return BlockList[i].OnTriggerEnterPlayerAsObservable();
        }

        public void DestroyBlock(int i)
        {
            BlockList[i].DestroyBlock();
        }
    }
}