namespace Tanks
{
    public static class TransferSettings
    {
        private static float _volume = 50;
        private static float _playerLifes = 5;
        private static float _botLifes = 3;
        private static float _botsCount = 6;

        public static float Volume 
        { 
            get  => _volume; 
            set =>  _volume = value; 
        }
        public static float PlayerLifes 
        { 
            get => _playerLifes; 
            set => _playerLifes = value; 
        }
        public static float BotLifes 
        { 
            get => _botLifes; 
            set => _botLifes = value; 
        }
        public static float BotsCount 
        { 
            get => _botsCount; 
            set => _botsCount = value; 
        }
    }
}
