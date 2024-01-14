using ai_gomoku.Command;
using ai_gomoku.Factory;
using ai_gomoku.Models;
using ai_gomoku.Role;
using System;
using System.Collections.Generic;

namespace ai_gomoku
{

    public class RoleMgr
    {
        private Dictionary<int, RoleBase> _roleOrderMap = new Dictionary<int, RoleBase>();

        private RoleBase _currentTurnRole;

        private GameModel _gameModel;

        private Form1 _view;

        private GameDef.PlayerType _player1;

        private GameDef.PlayerType _player2;

        private int _orderNum;

        public RoleMgr(Form1 view, GameDef.PlayerType player1, GameDef.PlayerType player2, GameDef.JudgeType judgeType)
        {
            Console.WriteLine($"Board is {GameDef.board_cell_length} x {GameDef.board_cell_length}");

            _gameModel = new GameModel();
            _view = view;

            _player1 = player1;
            _player2 = player2;

            var random = new Random();

            int num = random.Next(0, 2); //0、1
            GameDef.PlayerType blackPlayer = num == 0 ? _player1 : _player2;
            GameDef.PlayerType whitePlayer = num == 0 ? _player2 : _player1;

            //assume black chess order is first 
            _roleOrderMap.Add(0, PlayerFactory.CreatePlayer(blackPlayer, _view, _gameModel, this, ChessType.Black));
            _roleOrderMap.Add(1, JudgeFactory.CreateJudge(judgeType, GameDef.BLACK_CHESS_JUDGE + "_" + blackPlayer.ToString(), _view, _gameModel, this, ChessType.Black));
            _roleOrderMap.Add(2, PlayerFactory.CreatePlayer(whitePlayer, _view, _gameModel, this, ChessType.White));
            _roleOrderMap.Add(3, JudgeFactory.CreateJudge(judgeType, GameDef.WHITE_CHESS_JUDGE + "_" + whitePlayer.ToString(), _view, _gameModel, this, ChessType.White));

            _orderNum = 0;
            _currentTurnRole = _roleOrderMap[_orderNum];
        }
        public void Start()
        {
            _currentTurnRole.OnMyTurn();
        }
        public void RenewGame()
        {
            _gameModel.Init();

            _view.InitViewBoard();

            Player.InitTotalTurn();

            _orderNum = 0;
            _currentTurnRole = _roleOrderMap[_orderNum];
            _currentTurnRole.OnMyTurn();
        }
        public void ReturnHome()
        {
            _gameModel.Init();

            _view.InitViewBoard();

            Player.InitTotalTurn();
        }
        public void ChangeNextRole()
        {
            _orderNum++;

            if (_orderNum >= _roleOrderMap.Count)
            {
                _orderNum = 0;
            }

            _currentTurnRole = _roleOrderMap[_orderNum];
            //Thread.Sleep(200);
            _currentTurnRole.OnMyTurn();
        }
        public void ChangeComputerToPlay()
        {
            GameDef.PlayerType changeAIType = GameDef.PlayerType.HardAI;

            _roleOrderMap[_orderNum] = PlayerFactory.CreatePlayer(changeAIType, _view, _gameModel, this, _currentTurnRole.GetChessType());

            int judgeOeder = _orderNum + 1;
            _roleOrderMap[judgeOeder].AppendName($" + {changeAIType.ToString()}");

            _currentTurnRole = _roleOrderMap[_orderNum];
            _currentTurnRole.OnMyTurn();

        }
        public void PreviousPlayer()
        {
            _orderNum -= 2;
            if (_orderNum < 0)
            {
                _orderNum = _roleOrderMap.Count - 2;
            }

            _currentTurnRole = _roleOrderMap[_orderNum];
            _currentTurnRole.OnMyTurn();
        }

        public void PreviousPlayerByJudge()
        {
            _orderNum -= 1;
            if (_orderNum < 0)
            {
                throw new Exception("error OrderNum < 0");
            }

            _currentTurnRole = _roleOrderMap[_orderNum];
            _currentTurnRole.OnMyTurn();
        }

        public void PreviousPlayerByJudgeContainAI()
        {
            _orderNum -= 3;
            if (_orderNum < 0)
            {
                _orderNum = _roleOrderMap.Count - 2;
            }

            _currentTurnRole = _roleOrderMap[_orderNum];
            _currentTurnRole.OnMyTurn();
        }

        public bool IsAnyPlayerAi()
        {
            if (_player1.ToString().Contains("Human") && _player2.ToString().Contains("Human"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void LoadBorad()
        {
            ChessType none = ChessType.None;
            ChessType blac = ChessType.Black;
            ChessType whit = ChessType.White;

            if (GameDef.board_cell_length != 15)
            {
                Console.WriteLine("cannot Load board, because not 15X15 Board");
                return;
            }


            ChessType[,] board = new ChessType[15, 15]
                            {  
                                // 0     1     2     3     4     5     6     7     8     9     10    11    12    13    14       
                                { none, none, none, none, none, none, none, none, none, none, none, none, none, none, none},//0
                                { none, none, none, none, none, none, none, none, none, none, none, none, none, none, none},//1
                                { none, none, none, none, none, blac, none, none, none, none, none, none, none, none, none},//2
                                { none, none, none, none, none, whit, none, none, none, none, none, none, none, none, none},//3
                                { none, none, none, whit, blac, whit, none, none, none, none, whit, none, none, none, none},//4
                                { none, none, none, blac, blac, whit, blac, blac, none, blac, blac, none, none, none, none},//5
                                { none, none, none, blac, whit, whit, whit, whit, blac, none, none, none, none, none, none},//6
                                { none, none, blac, blac, whit, blac, blac, blac, whit, none, none, none, none, none, none},//7
                                { none, blac, none, blac, whit, whit, whit, whit, blac, none, none, none, none, none, none},//8
                                { whit, blac, whit, whit, whit, blac, none, none, none, none, none, none, none, none, none},//9
                                { none, none, whit, whit, blac, blac, none, none, none, none, none, none, none, none, none},//10
                                { none, none, whit, none, none, none, none, none, none, none, none, none, none, none, none},//11
                                { none, blac, none, none, none, none, none, none, none, none, none, none, none, none, none},//12
                                { none, none, none, none, none, none, none, none, none, none, none, none, none, none, none},//13
                                { none, none, none, none, none, none, none, none, none, none, none, none, none, none, none},//14
                            };

            int playedCount = 0;

            for (int y = 0; y < 15; ++y)
            {
                for (int x = 0; x < 15; ++x)
                {
                    if (board[y, x] != ChessType.None)
                    {
                        playedCount += 1;

                        _gameModel.PutChessToBoard(x, y, board[y, x]);

                        ChessBase myChess = ChessFactory.CreateChess(board[y, x]);
                        myChess.SetPositionByCoordinate(x, y);
                        _view.PutChessOnView(myChess);
                    }
                }
            }

            Player.TotalTurn = playedCount;

            _orderNum = playedCount % 2 == 0 ? 0 : 2;
            _currentTurnRole = _roleOrderMap[_orderNum];
            _currentTurnRole.OnMyTurn();
        }

        public void OnCommand(CommandBase command)
        {
            _currentTurnRole.OnCommand(command);
        }
    }
}
