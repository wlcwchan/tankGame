using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battlefield.GameLogic;
using System.Collections;
using System.Windows;

namespace Battlefield
{
    public partial class mainApp : Form
    {
        private const int TANK_NUMBER = 4;
        private const int GAMEBOARD_SIZE = 9;
        private const int TANK_SIZE = 4;
        private const int FORTRESS_HITPOINT = 1000;
        GameBoard gameBoard = new GameBoard(TANK_NUMBER, GAMEBOARD_SIZE, TANK_SIZE);
        private static ArrayList enemyTanks = new ArrayList();
        private static Fortress fortressHitPoints = new Fortress(FORTRESS_HITPOINT);
        private static bool isHit;
        private static bool gameFinished;

        public mainApp()
        {
            InitializeComponent();
            initalizeGame();
        }

        private void initalizeGame()
        {
            assignLabels();
            enemyTanks = gameBoard.getEnemyTanks();
        }

        private void assignLabels()
        {
            String[,] tankList = gameBoard.getTankGrid();
            for (int row = 0; row < gameGrid.RowCount; row++)
            {
                for (int column = 0; column < gameGrid.ColumnCount; column++)
                {
                    Label label = new Label();
                    String labelText = String.Format("{0},{1}", row, column);
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    label.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                    label.Margin = new System.Windows.Forms.Padding(0);
                    label.Image = Properties.Resources.FOG;
                    gameGrid.Controls.Add(label, row, column);
                    label.Click += (sender, e) => label_Click(sender, e, labelText, label, row, column);
                }
            }
        }

        private void label_Click(object sender, EventArgs e, String coordinate, Label label, int x, int y)
        {
            if (!gameFinished)
            {
                bool tankAliveCondition = false;
                isHit = GameUtilities.tankHit(enemyTanks, coordinate);
                gameBoard.updateGrid(coordinate, isHit);
                updateTextBox(isHit ? "Hit" : "Miss");

                if (!isHit && gameBoard.getGrid()[x - 1, y - 1].Equals(GameBoard.MARKER_TANK_HIT))
                {
                    label.Image = Properties.Resources.HIT;
                }
                else
                {
                    label.Image = isHit? Properties.Resources.HIT : Properties.Resources.MISS;
                    label.AutoSize = true;
                }

                tankDamageCalculation();

                updateTextBox(String.Format("Fortress HP:{0}", fortressHitPoints.getHitpoints().ToString()));
               
                if (GameUtilities.isTanksDestroyed(enemyTanks, TANK_NUMBER))
                {
                    tankAliveCondition = true;
                }

                if (tankAliveCondition == true || !GameUtilities.isFortressDestroyed(fortressHitPoints.getHitpoints()))
                {
                    endGameProcessing(tankAliveCondition);
                }
            }
        }

        public void updateLosingBoard(String[,] finalBoard, int gameBoardSize)
        {
            for (int row = 0; row < gameBoardSize; row++)
            {
                for (int col = 0; col < gameBoardSize; col++)
                {
                    if (finalBoard[row, col].Equals(GameBoard.MARKER_TANK))
                    {
                        gameGrid.GetControlFromPosition(row, col).Text = "tank";
                    }
                }
            }
        }

        private void endGameProcessing(bool tankAliveCondition)
        {
            updateLosingBoard(gameBoard.getLosingGrid(), GAMEBOARD_SIZE);
            MessageBox.Show(tankAliveCondition ? "YOU WIN" : "YOU LOSE");
            gameFinished = true;
            Close();
        }

        private void tankDamageCalculation()
        {
            foreach (Tank tank in enemyTanks)
            {
                updateTextBox(tank.getDamage().ToString());
                fortressHitPoints.subtractHitPoints(tank.getDamage());
            }
        }

        public void updateTextBox(String message)
        {
            messageBox.AppendText(String.Format("{0}{1}", message, Environment.NewLine));
            messageBox.SelectionStart = messageBox.Text.Length;
            messageBox.ScrollToCaret();
        }
    }
}
