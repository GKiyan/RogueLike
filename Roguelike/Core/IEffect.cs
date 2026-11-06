namespace Roguelike.Core
{
    public interface IEffect
    {
        EffectType Type { get; set; }
        int Duration { get; set; }
        bool IsExpired { get; set; }

        void OnApply(ITargetable target);
        void OnExpire(ITargetable target);
        void OnTick(ITargetable target);
    }
}