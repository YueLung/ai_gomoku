namespace ai_gomoku.Evaluation
{
    public interface IEvaluation
    {
        int GetScore(Model model, ChessType chessType);
    }
}
