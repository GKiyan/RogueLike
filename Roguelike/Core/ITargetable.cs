namespace Roguelike.Core
{
    public interface ITargetable
    {
        List<IEffect> ActiveEffects { get; set; }
        
        int Hp { get; set; }
        int MaxHp { get; set; }
        int Atk { get; set; }
        int MaxAtk { get; set; }
        int Def { get; set; }
        int MaxDef { get; set; }
        
        
        int GetStat(StatType stat);
        void TakeDamage(int amount);
        void Heal(int amount);
        void ApplyEffect(IEffect effect, ITargetable source);
        bool IsAlive();
    }
}