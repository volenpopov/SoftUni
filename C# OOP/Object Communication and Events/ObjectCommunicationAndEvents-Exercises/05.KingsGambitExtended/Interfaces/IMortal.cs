namespace _02.KingsGambit.Interfaces
{
    public delegate void GetKilledEventHandler(ISubordinate subordinate);

    public interface IMortal
    {
        event GetKilledEventHandler GetKilledEvent;

        void ReceiveStrike();
    }
}
