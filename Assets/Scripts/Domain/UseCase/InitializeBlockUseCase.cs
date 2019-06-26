using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Domain.UseCase
{
    public class InitializeBlockUseCase : IInitializable, IInitializeBlockUseCase
    {
        [Inject] private IBlockPresenter blockPresenter;

        void IInitializable.Initialize()
        {
            blockPresenter.InstantiateBlock(new Vector3(0, 1, 3));
            blockPresenter.InstantiateBlock(new Vector3(0, 1, -3));
            blockPresenter.InstantiateBlock(new Vector3(3, 1, 0));
            blockPresenter.InstantiateBlock(new Vector3(-3, 1, 0));
            blockPresenter.InstantiateBlock(new Vector3(1.5f, 1, 1.5f));
            blockPresenter.InstantiateBlock(new Vector3(1.5f, 1, -1.5f));
            blockPresenter.InstantiateBlock(new Vector3(-1.5f, 1, -1.5f));
            blockPresenter.InstantiateBlock(new Vector3(-1.5f, 1, 1.5f));
        }
    }

    public interface IInitializeBlockUseCase
    {

    }
}