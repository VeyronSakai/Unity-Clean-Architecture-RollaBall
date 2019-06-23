using UnityEngine;

namespace Presentation.Presenter
{
    public interface IPlayerView {
        Transform Tr{get;}
        void UpdatePosition(Vector3 pos);
    }
}
