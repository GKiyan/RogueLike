namespace Roguelike.Characters
{
    public class Team
    {
        public CharacterDuo[]? Duos { get; internal set; }
        public int Sp { get; set; }
        public int MaxSp { get; set; }
        public int UltimateCharge { get; set; }
        public int MaxUltimateCharge { get; set; }

        public Team(CharacterDuo frontDuo, CharacterDuo? midDuo = null, CharacterDuo? backDuo = null)
        {
            Duos = new CharacterDuo[3];
            Duos[0] = frontDuo;
            Duos[1] = midDuo;
            Duos[2] = backDuo;
            Sp = 3;
            MaxSp = 20;
            UltimateCharge = 0;
            MaxUltimateCharge = 20;
        }

        public void GainSP()
        {
            Sp++;
            if (Sp > MaxSp)
                Sp = MaxSp;
        }

        public void UseSP(int amount)
        {
            if (Sp >= amount)
            {
                Sp -= amount;
                if (Sp < 0)
                    Sp = 0;

                UltimateCharge += amount;
                if (UltimateCharge > MaxUltimateCharge)
                    UltimateCharge = MaxUltimateCharge; 
            }
        }

        public void SetFrontDuo(CharacterDuo duo)
        {
            Duos[0] = duo;
        }

        public void SetMidDuo(CharacterDuo? duo)
        {
            Duos[1] = duo;
        }

        public void SetBackDuo(CharacterDuo? duo)
        {
            Duos[2] = duo;
        }

        public CharacterDuo? GetDuoByPosition(int position)
        {
            if (position < 0 || position >= Duos.Length)
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be between 0 and 2.");

            return Duos[position];
        }
    }
}