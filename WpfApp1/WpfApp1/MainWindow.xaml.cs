///////////////////////////////////////////////////////////////////////
// MainWindow.xaml.cs -    handle logic for the main window          //
//                                                                   //
// ver 1.0                                                           //
// Author: Bo Qiu          Master in Computer Engineering,           //
//                         Syracuse University                       //
//                         (315) 278-2362, bqiu03@syr.edu            //
///////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace WpfApp1
{
  
    
    public class player
    {
        public String value { set; get; }
        public int id { set; get; }
        public player(int _id, String _value)
        {
            value = _value;
            id = _id;
        }
    }
    public partial class MainWindow : Window
    {
        player current_player { set; get; }
        player player1 { set; get; }
        player player2 { set; get; }
        int[,] board { set; get; }
        int count { set; get; }
        public MainWindow()
        {
            restart_game();
        }

        // O represents player1, X represents player2;
        public void player_initial()
        {
            player1  = new player(1, "O");
            player2 = new player(2, "X");
            current_player = player1;
        }
        //initial game board;
        public void game_board_inital()
        {
            count = 8;
            board = new int[3, 3];
            for( int i=0; i <3;i++)
            {
                for (int j = 0; j < 3; j++)
                    board[i,j] = 0;
            }
        }
        // after finishing game, restart it;
        public void restart_game()
        {
            InitializeComponent();
            player_initial();
            init_print();
            game_board_inital();
        }
        //initial UI interface
        public void init_print()
        {
            value0_0.Content = "";
            value0_1.Content = "";
            value0_2.Content = "";
            value1_0.Content = "";
            value1_1.Content = "";
            value1_2.Content = "";
            value2_0.Content = "";
            value2_1.Content = "";
            value2_2.Content = "";


        }
        //after every player's action, check winner
        public bool checkWinner()
        {
            int res = 0;
            for( int i=0; i <3;i++)
            {
               res=checkRow(i);
                if (res != 0)
                {
                    MessageBox.Show("Player" + res + " is Winner ");
                    restart_game();
                    return true;
                }
            }
         

            for (int i = 0; i < 3; i++)
            {
                res = checkCol(i);
                if (res != 0)
                {
                    MessageBox.Show("Player" + res + " is Winner ");
                    restart_game();
                    return true;
                }
            }
            res=checkLeftDiag();
            if (res != 0)
            {
                MessageBox.Show("Player" + res + " is Winner ");
                restart_game();
                return true;
            }
            res =checkRightDiag();
            if (res != 0)
            {
                MessageBox.Show("Player" + res + " is Winner ");
                restart_game();
                return true;
            }
            Console.WriteLine(count);
            if(count==0)
            {
                MessageBox.Show("Game end, no Winner");
                restart_game();
                return true;
            }
            return false;

        }
        //check diagonal
        public int checkLeftDiag()
        {
            if (board[0, 0] == 0) return 0;
            int start = board[0, 0];
            if (board[1, 1] == 0) return 0;
            if (start != board[1, 1]) return 0;
            if (board[2, 2] == 0) return 0;
            if (start != board[2, 2]) return 0;
            return start;
        }
        //check diagonal
        public int checkRightDiag()
        {
            if (board[0, 2] == 0) return 0;
            int start = board[0, 2];
            if (board[1, 1] == 0) return 0;
            if (start != board[1, 1]) return 0;
            if (board[2, 0] == 0) return 0;
            if (start != board[2, 0]) return 0;
            return start;
        }
        //check row by id;
        public int checkRow(int i)
        {
            if (board[i, 0] == 0) return 0;
            int start = board[i, 0];
            for( int j=1;j<3;j++)
            {
                if (board[i, j] == 0)
                    return 0;
                if (start != board[i, j])
                     return 0;
                
            }
            return start;
        }
        //check col by id;
        public int checkCol(int i)
        {
            if (board[0, i] == 0) return 0;
            int start = board[0, i];
            for (int j = 1; j < 3; j++)
            {
                if (board[j, i] == 0) return 0;
                
                    if (start != board[j, i])
                        return 0;
                
            }
            return start;
        }

        //button event
        private void Button_Click0_0(object sender, RoutedEventArgs e)
        {
          
            if (board[0, 0] == 0)
            {

                value0_0.Content = current_player.value;
                board[0, 0] = current_player.id;

                if (current_player == player1) current_player = player2;
                else current_player = player1;
             checkWinner();

            }

        }
        private void Button_Click0_1(object sender, RoutedEventArgs e)
        {
            if (board[0, 1] == 0)
            {

                value0_1.Content = current_player.value;
                board[0, 1] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
               
            }
        }
        private void Button_Click0_2(object sender, RoutedEventArgs e)
        {
            if (board[0, 2] == 0)
            {

                value0_2.Content = current_player.value;
                board[0, 2] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
            }
        }

        private void Button_Click1_0(object sender, RoutedEventArgs e)
        {
            if (board[1, 0] == 0)
            {

                value1_0.Content = current_player.value;
                board[1, 0] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
               checkWinner();
            }
        }
        private void Button_Click1_1(object sender, RoutedEventArgs e)
        {
            if (board[1, 1] == 0)
            {

                value1_1.Content = current_player.value;
                board[1, 1] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
            }
        }
        private void Button_Click1_2(object sender, RoutedEventArgs e)
        {
            if (board[1, 2] == 0)
            {

                value1_2.Content = current_player.value;
                board[1, 2] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
            }
        }

        private void Button_Click2_0(object sender, RoutedEventArgs e)
        {
            if (board[2, 0] == 0)
            {

                value2_0.Content = current_player.value;
                board[2, 0] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
            }
        }
        private void Button_Click2_1(object sender, RoutedEventArgs e)
        {
            if (board[2, 1] == 0)
            {

                value2_1.Content = current_player.value;
                board[2, 1] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
            }
        }
        private void Button_Click2_2(object sender, RoutedEventArgs e)
        {
            if (board[2, 2] == 0)
            {

                value2_2.Content = current_player.value;
                board[2, 2] = current_player.id;
                count--;
                if (current_player == player1) current_player = player2;
                else current_player = player1;
                checkWinner();
            }
        }
    }
}
