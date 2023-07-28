using Atomic;

namespace Homework.Scripts.Components
{
    public class TakeDamageComponent : ITakeDamageComponent
    {
        private readonly IAtomicAction<int> _onTakeDamage;

        public TakeDamageComponent(AtomicEvent<int> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
        }


        public void TakeDamage( int damage)
        {
           _onTakeDamage.Invoke(damage);
        }
    }
}