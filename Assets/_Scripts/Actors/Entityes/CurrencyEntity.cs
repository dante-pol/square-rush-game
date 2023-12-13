using DG.Tweening;

namespace Root.Assets._Scripts.Actors.Entityes
{
    public class CurrencyEntity : AEntity
    {
        public void Init()
        {

        }

        public override void Dispose()
        {
            gameObject.SetActive(false);
        }

        public override void CollisionWall()
        {
            transform.DOScale(0, .5f);
        }
    }
}
