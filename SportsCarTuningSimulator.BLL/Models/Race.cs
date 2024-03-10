namespace SportsCarTuningSimulator.BLL.Models
{
    public class Race
    {
        public enum TrackDifficulty
        {
            Easy,
            Medium,
            Hard
        }

        public string Name { get; set; }
        public TrackDifficulty Difficulty { get; set; }
        public Track RaceTrack { get; set; }
        public int PrizeMoney { get; set; }

        public Race(string name, TrackDifficulty difficulty, Track raceTrack, int prizeMoney)
        {
            Name = name;
            Difficulty = difficulty;
            RaceTrack = raceTrack;
            PrizeMoney = prizeMoney;
        }

        public void RunRace(List<Player> players)
        {
            
        }
    }
}