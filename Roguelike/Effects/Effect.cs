using Roguelike.Core;
using Roguelike.Characters;

namespace Roguelike.Effects
{
    public abstract class Effect : IEffect
    {
        public required EffectType Type { get; set; }
        public int Duration { get; set; }
        public int Amount;
        public bool IsExpired { get; set; }

        public Effect(EffectType type, int duration)
        {
            Type = type;
            Duration = duration;
        }

        public abstract void OnExpire(ITargetable target);
        public abstract void OnTick(ITargetable target);
        public abstract void OnApply(ITargetable target);
    }
}