def is_valid(board, row, col, num):
    # Check if the number can be placed in the given row and column
    for i in range(9):
        if (board[row][i] == num
                or board[i][col] == num
                or board[3 * (row // 3) + i // 3][3 * (col // 3) + i % 3] == num):
            return False
    return True


def find_empty_location(board):
    # Find an empty location (0) in the Sudoku board
    for i in range(9):
        for j in range(9):
            if board[i][j] == 0:
                return i, j
    return None, None


def solve_sudoku(board):
    row, col = find_empty_location(board)

    # If no empty location is found, the Sudoku puzzle is solved
    if row is None and col is None:
        return True

    # Try placing numbers 1 to 9
    for num in range(1, 10):
        if is_valid(board, row, col, num):
            # Place the number if it's valid
            board[row][col] = num

            # Recursively try to solve the rest of the puzzle
            if solve_sudoku(board):
                return True

            # If placing the current number doesn't lead to a solution, backtrack
            board[row][col] = 0

    # No solution found for this configuration
    return False
