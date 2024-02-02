import tkinter as tk
from tkinter import messagebox
from sudoku_solver import solve_sudoku
import requests
import time
import json

response = requests.get(url="https://sudoku-api.vercel.app/api/dosuku")
BOARD = response.json()["newboard"]["grids"][0]["value"]
DIFFICULTY = response.json()["newboard"]["grids"][0]["difficulty"]
DIFFICULTY_COLOR = "white"

if DIFFICULTY == "Easy":
    DIFFICULTY_COLOR = "green"
elif DIFFICULTY == "Medium":
    DIFFICULTY_COLOR = "yellow"
else:
    DIFFICULTY_COLOR = "red"


class SudokuGame:
    def __init__(self, window):
        self.root = window
        self.root.title("Sudoku Game")
        self.root.config(bg="black")
        self.board = BOARD
        self.difficulty = DIFFICULTY
        self.start_time = None
        self.timer_label = None
        self.start_button = None
        self.create_start_gui()

    def create_start_gui(self):
        # Create a "Start" button to initiate the game
        self.start_button = tk.Button(self.root, text="Start", command=self.create_board_gui)
        self.start_button.pack()

        # Display the last high score if available
        last_high_score = self.get_last_high_score()
        if last_high_score:
            last_high_score_label = tk.Label(self.root,
                                             text=f"Last High Score: {last_high_score['time']} ({last_high_score['difficulty']})")
            last_high_score_label.pack()

    def get_last_high_score(self):
        # Retrieve the last high score from the file
        try:
            with open("sudoku_high_scores.json", "r") as file:
                high_scores = json.load(file)
                if high_scores:
                    return high_scores[-1]
        except FileNotFoundError:
            pass  # The file doesn't exist yet
        return None

    def create_board_gui(self):
        # Destroy the "Start" button
        self.start_button.destroy()

        # Create and fill the Sudoku board GUI
        for i in range(9):
            for j in range(9):
                cell_value = self.board[i][j]
                cell_entry = tk.Entry(self.root, width=2, font=('Arial', 14))

                # Add thicker borders for subgrid separation
                padx_value = 2 if j % 3 == 0 and j != 0 else 0
                pady_value = 2 if i % 3 == 0 and i != 0 else 0

                cell_entry.grid(row=i, column=j, padx=(padx_value, 0), pady=(pady_value, 0))

                if cell_value != 0:
                    cell_entry.insert(0, str(cell_value))
                    cell_entry.config(state='disabled')

                cell_entry.grid(row=i, column=j)

        # Create labels for difficulty
        difficulty_label = tk.Label(self.root, text="Difficulty:", font=('Arial', 7, "bold"), fg="white", bg="black")
        difficulty_label.grid(row=10, column=0, columnspan=2)

        current_difficulty_label = tk.Label(self.root, text=self.difficulty, fg=DIFFICULTY_COLOR, bg="black")
        current_difficulty_label.grid(row=10, column=2, columnspan=2)

        # Create timer label
        self.timer_label = tk.Label(self.root, text="00:00")
        self.timer_label.grid(row=10, column=7, columnspan=2)

        # Create a button to solve the puzzle
        solve_button = tk.Button(self.root, text="Solve", command=self.solve_puzzle)
        solve_button.grid(row=9, column=1, columnspan=3)

        # Create a button to check the player's answer
        check_button = tk.Button(self.root, text="Check", command=self.check_solution)
        check_button.grid(row=9, column=5, columnspan=3)

        # Start the timer
        self.start_time = time.time()
        self.update_timer()

    def update_timer(self):
        # Update the timer label every second
        elapsed_time = int(time.time() - self.start_time)
        minutes = elapsed_time // 60
        seconds = elapsed_time % 60
        self.timer_label.config(text=f"{minutes:02d}:{seconds:02d}")
        self.root.after(1000, self.update_timer)

    def solve_puzzle(self):
        # Use the solving algorithm to fill in the solution
        if solve_sudoku(self.board):
            # Update the GUI to display the solved puzzle
            for i in range(9):
                for j in range(9):
                    cell_value = self.board[i][j]
                    cell_entry = tk.Entry(self.root, width=2, font=('Arial', 14))
                    cell_entry.insert(0, str(cell_value))
                    cell_entry.config(state='disabled')
                    cell_entry.grid(row=i, column=j)

        else:
            messagebox.showinfo("No Solution", "No solution exists for the given puzzle.")

    def check_solution(self):
        # Check if the current board configuration is a valid solution
        if self.is_valid_solution():
            messagebox.showinfo("Correct Solution", "Congratulations! You've solved the puzzle correctly.")
            # Stop the timer and save it
            self.root.after_cancel(self.update_timer)
            self.save_time()
        else:
            messagebox.showinfo("Incorrect Solution", "Your solution is incorrect. Keep trying!")

    def is_valid_solution(self):
        # Check if the current board configuration is a valid solution
        for i in range(9):
            for j in range(9):
                if self.board[i][j] == 0 or not self.is_valid(i, j, self.board[i][j]):
                    return False
        return True

    def is_valid(self, row, col, num):
        # Check if placing the given number at the given position is valid
        for i in range(9):
            if (self.board[row][i] == num or self.board[i][col] == num
                    or self.board[3 * (row // 3) + i // 3][3 * (col // 3) + i % 3] == num):
                return False
        return True

    def save_time(self):
        # Save the final time as a high score in a JSON file

        # Calculate the elapsed time
        elapsed_time = int(time.time() - self.start_time)
        minutes = elapsed_time // 60
        seconds = elapsed_time % 60
        final_time = f"{minutes:02d}:{seconds:02d}"

        # Read existing high score data from the file
        high_scores = []
        try:
            with open("sudoku_high_scores.json", "r") as file:
                high_scores = json.load(file)
        except FileNotFoundError:
            pass  # The file doesn't exist yet

        # Check if the current time is faster than the existing high score
        if not high_scores or elapsed_time < high_scores[-1]["time"]:
            # Update the high score with the current time
            data = {"difficulty": self.difficulty, "time": final_time}
            high_scores.append(data)

            # Save the updated high scores to the file
            with open("sudoku_high_scores.json", "w") as file:
                json.dump(high_scores, file)
