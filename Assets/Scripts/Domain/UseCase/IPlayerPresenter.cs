using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Presentation.Presenter;

namespace Domain.UseCase
{
    public interface IPlayerPresenter
    {
        Transform Tr { get; }
        IPlayerView CreatePlayer();
        void UpdatePlayerPosition(Vector3 pos);
    }
}