
using Syslib.Games.Sudoku;

namespace RealTimeSudokuSolver
{
	partial class ucSudokuBoard
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SudokuBoard = new System.Windows.Forms.Panel();
			this.lblTemplate = new System.Windows.Forms.Label();
			this.SudokuBoard.SuspendLayout();
			this.SuspendLayout();
			// 
			// SudokuBoard
			// 
			this.SudokuBoard.Controls.Add(this.lblTemplate);
			this.SudokuBoard.Location = new System.Drawing.Point(18, 26);
			this.SudokuBoard.Name = "SudokuBoard";
			this.SudokuBoard.Size = new System.Drawing.Size(467, 465);
			this.SudokuBoard.TabIndex = 1;
			// 
			// lblTemplate
			// 
			this.lblTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTemplate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblTemplate.Location = new System.Drawing.Point(19, 17);
			this.lblTemplate.Name = "lblTemplate";
			this.lblTemplate.Size = new System.Drawing.Size(36, 39);
			this.lblTemplate.TabIndex = 1;
			this.lblTemplate.Text = "9";
			this.lblTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ucSudokuBoard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SudokuBoard);
			this.Name = "ucSudokuBoard";
			this.Size = new System.Drawing.Size(598, 563);
			this.SudokuBoard.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel SudokuBoard;
		private System.Windows.Forms.Label lblTemplate;

		System.Windows.Forms.Label[] m_numberarray;
		int m_boardsize = 0;

		//		private 
		public void SetupBoard(int rows, int columns)
		{
			this.m_boardsize = rows * columns;
			if (this.m_boardsize <= 0) return;
			this.m_numberarray = new System.Windows.Forms.Label[this.m_boardsize];

			this.lblTemplate.Visible = false;
			int left = this.lblTemplate.Left;
			int top = this.lblTemplate.Top;
			int row = 0,  column = 0;


			for (int i = 0; i < this.m_boardsize; i++) 
			{
				this.m_numberarray[i] = new System.Windows.Forms.Label();
				this.m_numberarray[i].Font = lblTemplate.Font;
				this.m_numberarray[i].BorderStyle = lblTemplate.BorderStyle;
				this.m_numberarray[i].Location = new System.Drawing.Point(19, 17);
				this.m_numberarray[i].Name = "Number";
				this.m_numberarray[i].Size = lblTemplate.Size;
				this.m_numberarray[i].TabIndex = i + 1;
				this.m_numberarray[i].Text = ".";
				this.m_numberarray[i].TextAlign = lblTemplate.TextAlign;
				this.SudokuBoard.Controls.Add(this.m_numberarray[i]);
				this.m_numberarray[i].Left = this.lblTemplate.Left;
				this.m_numberarray[i].Top = this.lblTemplate.Top;


				if (++column < columns)
				{
					if (column % 3 == 0) this.lblTemplate.Left += this.lblTemplate.Width + 12;
					else this.lblTemplate.Left += this.lblTemplate.Width;
				}
				else
				{
					row++;
					this.lblTemplate.Left = left;
					if (row % 3 == 0) this.lblTemplate.Top += this.lblTemplate.Height + 12;
					else this.lblTemplate.Top += this.lblTemplate.Height;
					column = 0;
				}


			}



		}

		public void UpdateBoard(ISudoku sudoku) 
		{
			if (sudoku.Puzzle.Length != this.m_boardsize) return;
			int position = 0;
			foreach (var ch in sudoku.Puzzle) 
			{
				this.m_numberarray[position++].Text = ch.ToString();
			}
		}

	}
}
