using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syslib;

namespace RealTimeSudokuSolver
{
	public partial class RTSolver : Form
	{
		public RTSolver()
		{
			InitializeComponent();
			RTSolverInit();
		}

		private void tbSudokuInput_TextChanged(object sender, EventArgs e)
		{
			if (this.m_firstEdit)
			{
				this.m_firstEdit = false;
				tbSudokuInput.Text = "";
				tbSudokuInput.ForeColor = System.Drawing.Color.Black;
			}
			this.SolveInput();
		}

		private void btnSolution_Click(object sender, EventArgs e)
		{
			this.tbSudokuInput.Text = this.m_sudokusolver.Solution.Puzzle;
			this.FormatSudokuInput();
		}

		private void btnFormat_Click(object sender, EventArgs e)
		{
			this.FormatSudokuInput();
		}
	}
}
