using System;

namespace Game2048
{
    public class Model
    {
        private static Random _random = new Random();

        private Map _map;
        private bool _isGameOver;
        private bool _isMoved;

        public int MapSize { get => _map.size; }
        public int ScoreResult { get; set; }

        public Model(int mapSize)
        {
            _map = new Map(mapSize);
        }


        public void Start()
        {
            _isGameOver = false;

            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    _map.Set(x, y, 0);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                AddRandomNumber();
            }
        }


        public bool IsGameOver()
        {
            if (_isGameOver)
            {
                return _isGameOver;
            }

            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    if (_map.Get(x, y) == 0)
                    {
                        return false;
                    }
                }
            }

            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    int valueByXY = _map.Get(x, y);
                    int valueAtRight = _map.Get(x + 1, y);
                    int valueAtBottom = _map.Get(x, y + 1);

                    if (valueByXY == valueAtRight || valueByXY == valueAtBottom)
                    {
                        return false;
                    }
                }
            }

            _isGameOver = true;
            return _isGameOver;
        }

        private void AddRandomNumber()
        {
            if (_isGameOver)
            {
                return;
            }

            for (int i = 0; i < 100; i++)
            {
                int x = _random.Next(0, _map.size);
                int y = _random.Next(0, _map.size);

                if (_map.Get(x, y) == 0)
                {
                    _map.Set(x, y, _random.Next(1, 3) * 2);
                    return;
                }
            }

        }

        private void Lift(int x, int y, int sx, int sy)
        {
            if (_map.Get(x, y) > 0)
            {
                while (_map.Get(x + sx, y + sy) == 0)
                {
                    _map.Set(x + sx, y + sy, _map.Get(x, y));
                    _map.Set(x, y, 0);
                    x += sx;
                    y += sy;
                    _isMoved = true;
                }
            }
        }

        void Join(int x, int y, int sx, int sy)
        {
            if (_map.Get(x, y) > 0)
            {
                if (_map.Get(x + sx, y + sy) == _map.Get(x, y))
                {
                    _map.Set(x + sx, y + sy, _map.Get(x, y) * 2);
                    ScoreResult += (_map.Get(x, y) * 2);
                    while (_map.Get(x - sx, y - sy) > 0)
                    {
                        _map.Set(x, y, _map.Get(x - sx, y - sy));
                        x -= sx;
                        y -= sy;
                    }

                    _map.Set(x, y, 0);
                    _isMoved = true;
                }
            }

        }

        public void Left()
        {
            _isMoved = false;
            for (int y = 0; y < _map.size; y++)
            {
                for (int x = 1; x < _map.size; x++)
                {
                    Lift(x, y, -1, 0);
                }

                for (int x = 1; x < _map.size; x++)
                {
                    Join(x, y, -1, 0);
                }
            }

            if (_isMoved)
            {
                AddRandomNumber();
            }
        }

        public void Right()
        {
            _isMoved = false;
            for (int y = 0; y < _map.size; y++)
            {
                for (int x = _map.size - 2; x >= 0; x--)
                {
                    Lift(x, y, 1, 0);
                }
                for (int x = _map.size - 2; x >= 0; x--)
                {
                    Join(x, y, 1, 0);
                }
            }

            if (_isMoved)
            {
                AddRandomNumber();
            }
        }

        public void Up()
        {
            _isMoved = false;
            for (int x = 0; x < _map.size; x++)
            {
                for (int y = 1; y < _map.size; y++)
                {
                    Lift(x, y, 0, -1);
                }

                for (int y = 1; y < _map.size; y++)
                {
                    Join(x, y, 0, -1);
                }
            }

            if (_isMoved)
            {
                AddRandomNumber();
            }
        }

        public void Down()
        {
            _isMoved = false;
            for (int x = 0; x < _map.size; x++)
            {
                for (int y = _map.size - 2; y >= 0; y--)
                {
                    Lift(x, y, 0, 1);
                }

                for (int y = _map.size - 2; y >= 0; y--)
                {
                    Join(x, y, 0, 1);
                }
            }

            if (_isMoved)
            {
                AddRandomNumber();
            }
        }

        public int GetMap(int x, int y)
        {
            return _map.Get(x, y);
        }
    }
}
