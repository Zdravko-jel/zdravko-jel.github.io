from sudoku_game import SudokuGame
from tkinter import *

# Initializing a new TkInter window
window = Tk()

# passing this window to the game class
game = SudokuGame(window)

# keeping the window opened as long as needed
window.mainloop()

