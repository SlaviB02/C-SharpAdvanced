using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players => this.players;
        public int Count => this.players.Count;
        public Team(string name,int openPostions,char group)
        {
            this.Name = name;
            this.OpenPositions = openPostions;
            this.Group = group;
            this.players = new List<Player>();
        }
        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }
            else
            {
                this.players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }
        public bool RemovePlayer(string name)
        {
            var seachedPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if(seachedPlayer!=null)
            {
                this.Players.Remove(seachedPlayer);
                this.OpenPositions++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = 0;
            while(this.Players.FirstOrDefault(x=>x.Position==position)!=null)
            {
                var removedPlayer = this.Players.FirstOrDefault(x => x.Position == position);
                this.Players.Remove(removedPlayer);
                removedPlayers++;
                this.OpenPositions++;
            }
                return removedPlayers;
            
        }
        public Player RetirePlayer(string name)
        {
            var seachedPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            if (seachedPlayer != null)
            {
                seachedPlayer.Retired = true;
                return seachedPlayer;
            }
            else
            {
                return null;
            }
        }
        public List<Player>AwardPlayers(int games)
        {
            List<Player> awardedPlayers = new List<Player>();
            foreach (var player in this.Players.Where(x => x.Games >= games))
            {
                awardedPlayers.Add(player);
            }
            return awardedPlayers;
           
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach(var person in this.Players.Where(x=>x.Retired!=true))
            {
                sb.AppendLine(person.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
