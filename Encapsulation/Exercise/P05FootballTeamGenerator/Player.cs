namespace FootballTeamGenerator
{
    public class Player
    {

        //Palayer -> Name, int (Stats: endurance, sprint, dribble, passing, and shooting.) 


        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int shooting, int passing, int drible)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Shooting = shooting;
            Passing = passing;
            Drible = drible;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name should not be empty.");

                name = value;
            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentException($"{nameof(Endurance)} should be between 0 and 100.");

                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {

                if (value < 0 || value > 100) throw new ArgumentException($"{nameof(Sprint)} should be between 0 and 100.");

                sprint = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentException($"{nameof(Shooting)} should be between 0 and 100.");

                shooting = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentException($"{nameof(Passing)} should be between 0 and 100.");

                passing = value;
            }
        }
        public int Drible
        {
            get { return dribble; }
            private set
            {
                if (value < 0 || value > 100) throw new ArgumentException($"{nameof(Drible)} should be between 0 and 100.");

                dribble = value;
            }
        }

        public double SkillLevel => (Endurance + Sprint + Drible + Passing + Shooting) / 5.0;
    }

}
