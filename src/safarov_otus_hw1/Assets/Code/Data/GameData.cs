using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/Game/LevelData")]
    public sealed class GameData : ScriptableObject
    {
        [SerializeField] private int _speedBall;
        [SerializeField] private int _speedPaddle;
        [SerializeField] private int _hpBrick;
        [SerializeField] private Vector2 _countXY;
        [SerializeField] private int _life;



        public int SpeedBall
        {
            get { return _speedBall; }
        }

        public int SpeedPaddle
        {
            get { return _speedPaddle; }
        }

        public int HpBrick
        {
            get { return _hpBrick; }
        }

        public Vector2 CountXY
        {
            get { return _countXY; }
        }

        public int Life
        {
            get { return _life; }
        }
    }
}
