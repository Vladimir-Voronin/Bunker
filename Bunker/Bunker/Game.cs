using System;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    class Game
    {
        //Общие настройки
        public readonly int LevelAdd = 0;     //Константа, отвечающая за минимальный рубеж открытия позиций в начале игры
        public readonly int TimeTalkAlive = 0; //Константа, отвечающая за количество времени, дающееся на разговор живым игрокам (если равно 0, то время неограничено)
        public readonly int TimeToSurvive = 0; //Константа, отвечающая за количество времени, дающееся на разговор при схватке (если равно 0, то время неограничено)
        public readonly int PlayersToEnd = 4;

        //Общие условия игры
        public Position Cataclysm { get; set; } = new Catastrophe();

        //Делегаты

        public event Message.GameInfo GameIn;
         
        
        //Изменяющиеся поля и свойства

        //Количество игроков, оставшихся в отряде
        //public int AlivePlayers { get; set; }

        public int RoundNumber { get; set; }

        //Флаг-состояния раздачи карт
        public bool dealingcards = false;

        //Конструктор (добавляет нужные методы в делегаты, определяет количество игроков для конца игры, изменяет правила)
        public Game(bool MessageOn = false)
        {
            Message.FlagGameInfo = MessageOn;
            if (Message.FlagGameInfo == true) { GameIn += PrintMes; }
        }

        public Game(int leveladd, int timetalkalive, int timetosurvive, int playerstoend, bool MessageOn = false):this()
        {
            LevelAdd = leveladd;
            TimeTalkAlive = timetalkalive;
            TimeToSurvive = timetosurvive;
            PlayersToEnd = playerstoend;
        }

        //Метод для делегата/события (прогресс игры)
        public void PrintMes(string mes)
        {
            if (Message.FlagGameInfo == true) { Console.WriteLine(mes); }
        }


        //Отдельный метод создан для будущего расширения во front-end
        public void CreatePlayers(int many)
        {
            for (int i = 0; i < many; i++)
            {
                Player player = new Player();
            }
            
        }

        //Раздача карт (до начала игры)
        public void DealCards()
        {
            foreach (var player in Player.PlayersList)
            {
                player.CreateOrRefreshCard();
            }
            dealingcards = true;
            GameIn?.Invoke("Все игроки получили карты");
        }

        public void StartGame()
        {
            int many = 12; //Количество игроков
            GameIn?.Invoke("Игра началась");
            CreatePlayers(many);
            if (dealingcards == false) { DealCards(); }

            foreach (var player in Player.PlayersList)
            {
                player.IsAlive = true;
                //Открытие всех позиций, соотвтествующих уровню LevelAdd
                foreach (Position pos in player.PlayerCard.allpositions)
                {
                    if (pos.Levelhide <= LevelAdd) { pos.Open = true; }
                }
            }
            StartNewRound();
        }

        //Один проход по всем игрокам
        public void StartNewRound()
        {
            while(true)
            {
                if (Player.PlayersList.Count <= PlayersToEnd)
                {
                    GameIn?.Invoke("Игра окончена");
                    GameIn?.Invoke("В отряде остались игроки:");
                    foreach (var player in Player.PlayersList)
                    {
                        GameIn?.Invoke(player.Name);
                    }
                    break;
                }
                RoundNumber++;
                GameIn?.Invoke($"Начался раунд {RoundNumber}");
                //Таймер (подключить отдельно для возможности игры с таймером и без)
                foreach (var player in Player.PlayersList)
                {
                    if (player.IsAlive)
                    {
                        player.Talking(this);
                    }
                }
                GameIn?.Invoke("Начинается голосование");
                Voting(Player.PlayersList);


                //Как реализовать удаление игрока???

                //Обработка результатов голосования (передается список игроков, над которыми будет работать алгоритм)
                List<Player> tosurvive = ToSurvive(Player.PlayersList);
                DeleteOrSurviveRound(tosurvive);
            }
            

            
        }

        //Алгоритм определяет за кого проголосовало больше всего игроков
        public List<Player> ToSurvive(List<Player> Players)
        {
            List<Player> tosurvive = new List<Player>();
            int current = 0;
            int max = 0;
            foreach (var player in Players)
            {
                current = player.Vote;
                if (current > max)
                {
                    max = current;
                    tosurvive.Clear();
                    tosurvive.Add(player);
                }
                else if (current == max)
                {
                    tosurvive.Add(player);
                }
            }

            GameIn?.Invoke($"Максимальное количество голосов: {max}.");
            return tosurvive;
        }


        //Метод просматривает количество голосов, если есть лидер, то исключает его
        //Если таких игроков несколько, то проводит второй круг между игроками борющимися за выживание
        public void DeleteOrSurviveRound(List<Player> tosurvive)
        {
            if (tosurvive.Count == 1)
            {
                GameIn?.Invoke($"Игрок {tosurvive[0].Name} покидает игру");
                tosurvive[0].DeletePlayer();
                tosurvive.Remove(tosurvive[0]);
            }
            else
            {
                foreach (var player in tosurvive)
                {
                    player.Talking(this);
                }
            }
            Voting(tosurvive);
            List<Player> result = ToSurvive(tosurvive);
            foreach (var player in result)
            {
                GameIn?.Invoke($"Игрок {player.Name} покидает игру");
                player.DeletePlayer();
            }
        }

        //Голосование за исключение (слишком много вариантов реализации)
        public void Voting(List<Player> Players)
        {
           
            Random rand = new Random();
            foreach (var player in Players)
            {
                player.Vote = rand.Next(0, 4);
                Console.WriteLine($"{player.Name}: {player.Vote}");
            }
        }
    }
}
