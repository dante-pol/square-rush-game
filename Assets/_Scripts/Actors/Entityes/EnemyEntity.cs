using DG.Tweening;
using System;

namespace Root.Assets._Scripts.Actors.Entityes
{
    public class EnemyEntity : AEntity
    {
        public override void Dispose()
            => gameObject.SetActive(false);

        public override void CollisionWall()
            => transform.DOScale(0, .5f);

    }
}
