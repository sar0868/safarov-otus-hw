using UnityEngine;

namespace Code
{
    public sealed class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private int _level;
        [SerializeField] private Brick _brickPrefab;
        [SerializeField] private RowUpgradeData _rowUpgradeData;
        [SerializeField] private GameUpgradeData _gameUpgradeData;
        [SerializeField] private Ball _ballPrefabs;
        [SerializeField] private Paddle _paddlePrefabs;

        private const float Indent = 0.5f;
        private const int AspectRatio = 4;
        private const float FillingLimit = 0.75f;

        private int _countX;
        private int _countY;
        private float _left;
        private float _right;
        private float _top;
        private float _bottom;
        private float _currentLeft;
        private float _sizeX;
        private float _sizeY;
        private int _speedBall;
        private int _speedPaddle;
        private int _hpBrick;
        private int _life;

        public int Level { get => _level; set => _level = value; }

        private void Start()
        {
            GetLevelData();
            CreateLevel();
            CreatePaddle();
            CreateBall();
        }

        private void GetLevelData()
        {
            _gameUpgradeData.TryGetGameDataLevel(Level, out GameData gameData);
            _speedBall = gameData.SpeedBall;
            _speedPaddle = gameData.SpeedPaddle;
            Vector2 countXY = gameData.CountXY;
            _countX = (int)countXY.x;
            _countY = (int)countXY.y;
            _hpBrick = gameData.HpBrick;
            _life = gameData.Life;
        }

        private void CreateLevel()
        {
            SetSizes();
            for (int i = 0; i < _countY; i++)
            {
                _rowUpgradeData.TryGetRowDataLine(i, out RowData rowData);
                _currentLeft = _left;
                for (int j = 0; j < _countX; j++)
                {
                    Brick brick = Instantiate(
                        _brickPrefab,
                        new Vector3(_currentLeft, _top, 0f),
                        Quaternion.identity
                    );

                    Renderer childRenderer = brick.GetComponentInChildren<Renderer>();
                    childRenderer.material.color = rowData.Color;
                    brick.transform.localScale = new Vector3(_sizeX, _sizeY, 1);
                    brick.Hp = _hpBrick;

                    _currentLeft += _sizeX;
                    Main.CountBrick++;
                }
                _top -= _sizeY;
            }
        }

        private void SetSizes()
        {
            GetBorder();
            float lengthMap = _right - _left;
            float hightMap = _top - _bottom;
            _sizeX = lengthMap / _countX;
            float tempSizeY = _sizeX / AspectRatio;
            _sizeY = tempSizeY > Indent ? Indent : tempSizeY;
            float limitHight = FillingLimit * hightMap;
            if (_sizeY * _countY > limitHight)
            {
                _sizeY = limitHight / _countY;
            }
            _left += _sizeX / 2;
            _top -= _sizeY / 2;
        }

        private void CreateBall()
        {
            Ball _ball = Instantiate(_ballPrefabs);
            _ball.CreateBall();
            _ball.Speed = _speedBall;
            _ball.Life = _life;
        }

        private void CreatePaddle()
        {
            Vector3 sizePaddle = _paddlePrefabs.transform.localScale;
            float indentTop = sizePaddle.y + Indent;
            Vector3 positionPaddle = new Vector3(0f, _bottom + indentTop, 0f);
            Paddle paddle = Instantiate(_paddlePrefabs, positionPaddle, Quaternion.identity);
            paddle.Speed = _speedPaddle;
        }

        private void GetBorder()
        {
            _left = FindAnyObjectByType<LeftZone>().transform.position.x + Indent;
            _right = FindAnyObjectByType<RightZone>().transform.position.x - Indent;
            _top = FindAnyObjectByType<TopZone>().transform.position.y - Indent;
            _bottom = FindAnyObjectByType<DeadZone>().transform.position.y;
        }
    }
}
