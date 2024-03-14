#nullable disable
using SportsCarTuningSimulator.BLL.Models;
using SportsCarTuningSimulator.BLL.Services;

namespace SportsCarTuningSimulator.BLL.Builders
{
    public class GameBuilder
    {
        private Player _player;
        private int _rivalsCount;

        public GameBuilder WithPlayer(Player player)
        {
            _player = player;

            return this;
        }

        public GameBuilder WithRivalsCount(int count)
        {
            _rivalsCount = count;

            return this;
        }

        public Game Build()
        {
            if (_player == null)
            {
                throw new InvalidOperationException("Player must be provided.");
            }

            if (_rivalsCount <= 0)
            {
                throw new InvalidOperationException("Number of rivals must be greater than zero.");
            }

            return new Game(_player, _rivalsCount);
        }
    }
}