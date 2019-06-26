using System;
using UnityEngine;
using Domain.UseCase;
using Zenject;
using UniRx;
using UniRx.Triggers;

namespace Presentation.Presenter
{
    public class BlockPresenter : IBlockPresenter
    {
        [Inject] private IBlockView blockView;

        public IObservable<Unit> OnTriggerEnterPlayerAsObservable()
        {
            return blockView.OnTriggerEnterPlayerAsObservable();
        }
    }
}