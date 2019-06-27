using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UniRx;
using UniRx.Triggers;
using Domain.UseCase;
using Presentation.Presenter;

namespace Domain.UseCase
{
    public interface IBlockPresenter
    {
        void InstantiateBlock(Vector3 pos);
        IObservable<Unit> OnTriggerEnterPlayerAsObservable(int i);
        List<IBlockView> BlockList { get; set; }
        void DestroyBlock(int i);
    } 
}