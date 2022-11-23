using static System.Formats.Asn1.AsnWriter;

namespace Tennis
{
    public class TennisGameManager
    {
        private int p1point;
        private int p2point;

        private string Five_teen = "Fifteen";

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGameManager(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            p1point = 0;
        }

        public string Score_Getter()
        {
            var s = "";
            // when both have same points and game smaller than three
            if (p1point == p2point && p1point < 3){
                if (p1point == 0)
                    s = "Love";
                if (p1point == 1)
                {
                    s = "Fifteen";
                }
                if (p1point == 2)
                    s = "Thirty";
                s += "-All";
            }
            if (p1point == p2point && p1point > 2)
                s = "Deuce";

            if (p1point > 0 && p2point == 0)
            {
                if (p1point == 1)
                    p1res = Five_teen;
                if (p1point == 2)
                    p1res = "Thirty";
                if (p1point == 3)
                    p1res = "Forty";

                p2res = "Love";
                s = p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0)
            {
                var temp = p2point;
                if (temp == 1) 
                { 
                    p2res = "Fifteen"; 
                }
                if (temp == 2)
                {
                    p2res = "Thirty";
                }
                if (temp == 3)
                {
                    p2res = "Forty";
                }

                p1res = "Love";
                s = p1res + "-" + p2res;
            }
            if (p1point > p2point && p1point < 4){
                if (p1point == 2)
                {
                    p1res = "Thirty";
                }
                if (p1point == 3)
                {
                    p1res = "Forty";
                }
                if (p2point == 1)
                {
                    p2res = "Fifteen";
                }
                if (p2point == 2)
                {
                    p2res = "Thirty";
                }
                s = p1res + "-" + p2res;}



            if (p2point > p1point && p2point < 4)
            {
                if (p2point == 2)
                {
                    p2res = "Thirty";
                }
                if (p2point == 3)
                {
                    p2res = "Forty";
                }
                if (p1point == 1)
                {
                    p1res = "Fifteen";
                }
                if (p1point == 2)
                {
                    p1res = "Thirty";
                }
                s = p1res + "-" + p2res;
            }

            if (p1point > p2point && p2point >= 3)
            {
                s = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                s = generate_Player_2_Name();
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                s = "Win for player1";
            }
            s = returnWinForPlayerOneIfWon(s, p1point, p2point);
            return s;
        }

       

        private static string generate_Player_2_Name()
        {
            return "Advantage player2";
        }

        public string returnWinForPlayerOneIfWon(string s, int q, int y)
        {
            if (y >= 4 && q >= 0 && (y - q) >= 2)
            {
                return "Win for player2";
            }
            return s; 
        }

        public void SetPlayer1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                SecondPlayerScore();
            }
        }

        private void P1Score() => p1point++;
        private void SecondPlayerScore()
        {
            p2point++;
        }

        public void WonPoint(string tennisPlayer)
        {
            if (tennisPlayer == "player1"){
                P1Score();}
            else
                SecondPlayerScore();
        }

    }
}

