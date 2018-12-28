namespace _02.KingsGambit
{
    public delegate void GetAttackedEventHandler();

    public interface IAttackable
    {
        event GetAttackedEventHandler GetAttackedEvent;

        void GetAttacked();
    }
}
