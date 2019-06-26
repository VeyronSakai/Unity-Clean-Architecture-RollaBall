using UnityEngine;
using UniRx;

namespace Domain.Entity
{
    public class ScoreEntity : IScoreEntity
    {
        private ReactiveProperty<int> _scoreProperty;
        public IReadOnlyReactiveProperty<int> ScoreProperty => _scoreProperty;

        public ScoreEntity()
        {
            _scoreProperty = new ReactiveProperty<int>(0);
        }

        public void Increment()
        {
            _scoreProperty.Value++;
        }
    }

    public interface IScoreEntity
    {
        IReadOnlyReactiveProperty<int> ScoreProperty { get; }
        void Increment();
    }
}


