using System;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    class Game
    {
        //Общие настройки
        public const byte leveladd = 0;     //Константа, отвечающая за минимальный рубеж открытия позиций в начале игры
        public const int timetalkalive = 0; //Константа, отвечающая за количество времени, дающееся на разговор живым игрокам (если равно 0, то время неограничено)
        public const int timetosurvive = 0; //Константа, отвечающая за количество времени, дающееся на разговор при схватке (если равно 0, то время неограничено)
        //Общие условия игры
        public Position Cataclysm { get; set; } = new Catastrophe();
        
        //Изменяющиеся поля и свойства

        //Количество игроков, оставшихся в отряде
        public byte AlivePlayers { get; set; }

        //Флаг-состояния раздачи карт
        public bool dealingcards = false;

        //Отдельная функция создана для будущего расширения во front-end
        public Player CreatePlayer(string name)
        {
            Player player = new Player();
            return player;
        }

        //Раздача карт (до начала игры)
        public void DealCards()
        {
            foreach (var player in Player.PlayersList)
            {
                player.CreateOrRefreshCard();
            }
            dealingcards = true;
        }

        public void StartGame()
        {
            if(dealingcards == false) { DealCards(); }

            foreach (var player in Player.PlayersList)
            {
                player.IsAlive = true;
                foreach (Position pos in player.PlayerCard.allpositions)
                {
                    if (pos.Levelhide <= leveladd) { pos.Open = true; }
                }
            }
            StartNewRound();
        }

        //Один проход по всем игрокам
        public void StartNewRound()
        {
            //Таймер (подключить отдельно для возможности игры с таймером и без)
            foreach (var player in Player.PlayersList)
            {
                if(player.IsAlive)
                {
                    player.Talking();
                }
            }
            //Как реализовать удаление игрока???
        }
    }
}
