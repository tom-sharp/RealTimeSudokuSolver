using Syslib;
using Syslib.Games.Sudoku;

namespace RealTimeSudokuSolver
{
	partial class RTSolver
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbSudokuInput = new System.Windows.Forms.TextBox();
			this.btnSolution = new System.Windows.Forms.Button();
			this.btnFormat = new System.Windows.Forms.Button();
			this.lblInvalid = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbSudokuInput
			// 
			this.tbSudokuInput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.tbSudokuInput.Location = new System.Drawing.Point(559, 60);
			this.tbSudokuInput.Multiline = true;
			this.tbSudokuInput.Name = "tbSudokuInput";
			this.tbSudokuInput.Size = new System.Drawing.Size(364, 361);
			this.tbSudokuInput.TabIndex = 0;
			this.tbSudokuInput.TextChanged += new System.EventHandler(this.tbSudokuInput_TextChanged);
			// 
			// btnSolution
			// 
			this.btnSolution.Location = new System.Drawing.Point(436, 221);
			this.btnSolution.Name = "btnSolution";
			this.btnSolution.Size = new System.Drawing.Size(80, 45);
			this.btnSolution.TabIndex = 1;
			this.btnSolution.Text = "--->";
			this.btnSolution.UseVisualStyleBackColor = true;
			this.btnSolution.Click += new System.EventHandler(this.btnSolution_Click);
			// 
			// btnFormat
			// 
			this.btnFormat.Location = new System.Drawing.Point(559, 12);
			this.btnFormat.Name = "btnFormat";
			this.btnFormat.Size = new System.Drawing.Size(80, 34);
			this.btnFormat.TabIndex = 2;
			this.btnFormat.Text = "Format";
			this.btnFormat.UseVisualStyleBackColor = true;
			this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
			// 
			// lblInvalid
			// 
			this.lblInvalid.AutoSize = true;
			this.lblInvalid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblInvalid.ForeColor = System.Drawing.Color.DarkRed;
			this.lblInvalid.Location = new System.Drawing.Point(452, 149);
			this.lblInvalid.Name = "lblInvalid";
			this.lblInvalid.Size = new System.Drawing.Size(64, 25);
			this.lblInvalid.TabIndex = 3;
			this.lblInvalid.Text = "Invalid";
			// 
			// RTSolver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 522);
			this.Controls.Add(this.lblInvalid);
			this.Controls.Add(this.btnFormat);
			this.Controls.Add(this.btnSolution);
			this.Controls.Add(this.tbSudokuInput);
			this.Name = "RTSolver";
			this.Text = "RTSolver - Real Time Sudokusolver";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbSudokuInput;

		ucSudokuBoard m_SudokuBoard;
		CSudoku m_sudokuInput;
		CSudokuNumpassSolver m_sudokusolver;
		bool m_firstEdit;


		void RTSolverInit() 
		{

			this.m_SudokuBoard = new ucSudokuBoard();
			this.m_SudokuBoard.SetupBoard(rows: 9, columns:9);
			this.Controls.Add(this.m_SudokuBoard);

			this.m_sudokuInput = new CSudoku();
			this.m_sudokusolver = new CSudokuNumpassSolver();

			this.tbSudokuInput.ForeColor = System.Drawing.Color.Gray;
			this.tbSudokuInput.Text = "Copy/paste in here or enter text directly. \r\nValid characters are '1'-'9' and  '.', '0', 'x', '-', '_' for undefined numbers.    \r\nAny other are ignored and filtered out.";
			this.tbSudokuInput.Select(0,0);
			this.m_firstEdit = true;

			this.lblInvalid.Visible = false;

		}

		void SolveInput()
		{
			this.m_sudokuInput.SetPuzzle(this.tbSudokuInput.Text);
			this.m_sudokusolver.Solve(this.m_sudokuInput);
			this.m_SudokuBoard.UpdateBoard(this.m_sudokusolver.Solution);

			if (this.m_sudokusolver.Solution.GradeId != SudokuGrade.SolvedId)
				this.lblInvalid.Visible = true;
			else
				this.lblInvalid.Visible = false;

		}

		void FormatSudokuInput() 
		{
			var result = new CStr(130);
			int row = 0, column = 0;
			foreach (var ch in this.m_sudokuInput.Puzzle)
			{
				column++;
				result.Append(ch);

				if (column == 9) { result.Append("\r\n"); column = 0; row++; }
				else if (column % 3 == 0) { result.Append(' '); }

				if (row == 3) { result.Append("\r\n"); row = 0; }

			}
			this.tbSudokuInput.Text = result.ToString();

		}

		private System.Windows.Forms.Button btnSolution;
		private System.Windows.Forms.Button btnFormat;
		private System.Windows.Forms.Label lblInvalid;
	}
}