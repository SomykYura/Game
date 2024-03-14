namespace SportsCarTuningSimulator.BLL.Models
{
    public class GrandPrix
    {
        public IReadOnlyList<Race> Races { get; }

        private readonly List<Race> _races;

        public GrandPrix()
        {
            _races = new List<Race>();
            Races = _races.AsReadOnly();
        }

        public void AddRace(Race race)
        {
            if (race == null)
            {
                throw new ArgumentNullException(nameof(race), "Race cannot be null.");
            }

            _races.Add(race);
        }

        public void Reset()
        {
            foreach (var race in _races)
            {
                race.ClearResults();
            }
        }
    }
}