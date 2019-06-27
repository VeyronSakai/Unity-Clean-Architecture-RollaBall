using UnityEngine;
using Zenject;
using UniRx;

namespace Domain.Entity
{
    public class PlayerEntity : IPlayerEntity
    {
        private ReactiveProperty<Vector3> _playerPositionProperty;
        public IReadOnlyReactiveProperty<Vector3> PlayerPositionProperty => _playerPositionProperty;
        public Vector3 PlayerPostion => _playerPositionProperty.Value;

        public PlayerEntity()
        {
            _playerPositionProperty = new ReactiveProperty<Vector3>(new Vector3(0, 1, 0));
        }
    }
}

