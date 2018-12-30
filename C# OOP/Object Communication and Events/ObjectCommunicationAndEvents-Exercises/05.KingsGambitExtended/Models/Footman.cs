using _02.KingsGambit.Interfaces;
using _02.KingsGambit.Models;

namespace _02.KingsGambit
{
    public class Footman : Subordinate
    {
        public Footman(IKing king, string name)
            : base(king, name, "panicking")
        { }

        public override void ReceiveStrike()
        {
            base.ReceiveStrike();

            if (base.StrikesReceived >= 2)
                base.Die();
        }
    }
}
