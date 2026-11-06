using Roguelike.Core;

namespace Roguelike.Characters
{
    public class CharacterDuo : ITargetable
    {
        public MainCharacter MainCharacter { get; set; }
        public SupportCharacter SupportCharacter { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int MaxAtk { get; set; }
        public int Def { get; set; }
        public int MaxDef { get; set; }
        public int TotalSpeed => MainCharacter.GetStat(StatType.Speed) + SupportCharacter.GetStat(StatType.Speed);
        public List<IEffect> ActiveEffects { get; set; } = new List<IEffect>();

        public CharacterDuo(MainCharacter mainCharacter, SupportCharacter supportCharacter)
        {
            MainCharacter = mainCharacter;
            SupportCharacter = supportCharacter;
            TotalHP = TotalMaxHP;
        }

        public int GetStat(StatType stat)
        {
            switch (stat)
            {
                case StatType.HP:
                    return TotalHP;
                case StatType.DEF:
                    return TotalDEF;
                case StatType.MaxHP:
                    return TotalMaxHP;
                case StatType.Speed:
                    return TotalSpeed;
                default:
                    throw new ArgumentException("Invalid stat type");
            }
        }

        public void TakeDamage(int amount)
        {
            if (!IsAlive())
                throw new InvalidOperationException("Character duo is already dead.");
            TotalHP -= amount;
            if (TotalHP < 0)
                TotalHP = 0;
        }

        public void Heal(int amount)
        {
            if (!IsAlive())
                throw new InvalidOperationException("Character duo is dead and cannot be healed.");
            TotalHP += amount;
            if (TotalHP > TotalMaxHP)
                TotalHP = TotalMaxHP;
        }

        public void ApplyEffect(IEffect effect, ITargetable source)
        {
            ActiveEffects.Add(effect);
            effect.OnApply(this);
        }

        public bool IsAlive()
        {
            return TotalHP > 0;
        }

        public bool IsComboAvailable()
        {
            return MainCharacter.ComboId == SupportCharacter.ComboId;
        }

        public void UpdateEffects()
        {
            for (int i = ActiveEffects.Count - 1; i >= 0; i--)
            {
                var effect = ActiveEffects[i];
                effect.OnTick(this);
                if (effect.IsExpired)
                {
                    ActiveEffects.RemoveAt(i);
                }
            }
        }

        public ICharacter GetCharacterByType(CharacterType characterType)
        {
            return characterType switch
            {
                CharacterType.Main => MainCharacter,
                CharacterType.Support => SupportCharacter,
                _ => throw new ArgumentException("Invalid character type", nameof(characterType)),
            };
        }
    }
}