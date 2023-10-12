using System;
using Syslib.Games.Sudoku;
using Syslib;

namespace SudokuSolver
{
	class Program
	{
		static void Main(string[] args)
		{
			new SudokuSolver().Run();
		}

	}

	class SudokuSolver
	{
		CSudoku m_sudoku = new();
		CSudokuNumpassSolver m_solver = new();
		CList<ISudoku> m_puzzles = new();

		public void Run()
		{
			string input;

			// use pipe to redirect file to input.
			// Ex: sudokusolver < textFilewithpuzzles.txt

			Console.WriteLine("Reading puzzles from command line (empty line to exit)");

			while ((input = Console.ReadLine()) != null)
			{
				if (input.Length == 0) break;
				this.m_puzzles.Add(new CSudokuPuzzle(this.m_sudoku.SetPuzzle(input)));
			}
			this.SolvePuzzles();
		}

		void SolvePuzzles()
		{
			int solved = 0, invalid = 0;

			if (this.m_puzzles.Count() == 0) { Console.WriteLine("Nothing to solve"); return; }

			System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

			stopWatch.Start();
			foreach (var pz in this.m_puzzles)
			{
				Console.WriteLine($"{pz.Puzzle}   {SudokuGrade.GetGrade(pz.GradeId).Name}");
				this.m_solver.Solve(pz);
				Console.WriteLine($"{this.m_solver.Solution.Puzzle}   {SudokuGrade.GetGrade(this.m_solver.Solution.GradeId).Name}");
				if (this.m_solver.Solution.GradeId == SudokuGrade.SolvedId) solved++;
				else invalid++;
			}
			stopWatch.Stop();
			int puzzlespeed = (int)(solved/stopWatch.Elapsed.TotalSeconds);
			Console.Write($" Solved {solved}/{this.m_puzzles.Count()} puzzles" );
			if (solved == this.m_puzzles.Count()) Console.WriteLine($"  time  {stopWatch.Elapsed.TotalSeconds} Sec ({puzzlespeed} puzzles/sec)");
			else Console.WriteLine($"  {stopWatch.Elapsed.TotalSeconds} Sec  (invalid: {invalid})");
			if (solved > 0) Console.WriteLine($" Avarage {stopWatch.Elapsed.TotalMilliseconds/this.m_puzzles.Count():0.000} mSec/puzzle");
		}
	}

}
