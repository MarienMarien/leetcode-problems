public class SnakeGame {
    private int _width;
    private int _height;
    private int[,] _board;
    private IDictionary<string, int[]> _directions = 
        new Dictionary<string, int[]>{ {"R", [0, 1]}, {"D", [1, 0]}, {"L", [0, -1]}, {"U", [-1, 0]} };
    private LinkedList<(int row, int col)> _snake;
    private int[][] _food;
    private int _foodId;
    private int _score;

    public SnakeGame(int width, int height, int[][] food) {
        _board = new int[height, width];
        _height = height;
        _width = width;
        _score = 0;
        _food = food;
        _foodId = 0;
        var foodLocation = _food[_foodId];
        _board[foodLocation[0], foodLocation[1]] = 1;
        _snake = new LinkedList<(int row, int col)>();
        _board[0, 0] = -1;
        _snake.AddFirst((0, 0));
//        ShowBoard();
    }
    
    public int Move(string direction) {
        var headCurrPosition = _snake.Last.Value;
        var nextMove = _directions[direction];
        var newRow = headCurrPosition.row + nextMove[0];
        var newCol = headCurrPosition.col + nextMove[1];
        var tailCell = _snake.First.Value;
        if(newRow < 0 || newRow >= _height || newCol < 0 || newCol >= _width
            || (_board[newRow, newCol] == -1 && !(tailCell.row == newRow && tailCell.col == newCol)))
            return -1;
        if(_board[newRow, newCol] == 1)
        {
            _foodId++;
            if(_foodId < _food.Length)
            {
                var nextFoodLocation = _food[_foodId];
                _board[nextFoodLocation[0], nextFoodLocation[1]] = 1;
            }
            _score++;
        }
        else 
        {
            _snake.RemoveFirst();
            _board[tailCell.row, tailCell.col] = 0;
        }
        _board[newRow,newCol] = -1;
        _snake.AddLast((newRow, newCol));
 //       ShowBoard();
        return _score;
    }

    // private void ShowBoard()
    // {
    //     Console.WriteLine("=====");
    //     for(var row = 0; row < _height; row++)
    //     {
    //         for(var col = 0; col < _width; col++)
    //         {
    //             Console.Write($"{_board[row, col]} ");
    //         }
    //         Console.WriteLine();
    //     }
    //     Console.WriteLine("--------");
    //     foreach(var it in _snake)
    //     {
    //         Console.Write($"({it.row}, {it.col})");
    //     }
    //     Console.WriteLine();
    // }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */