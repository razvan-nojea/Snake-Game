using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat.classes
{
    public static class baza
    {
        private static string conn_path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Sarpe.mdf;Integrated Security=True;Connect Timeout=30";

        private static SqlConnection conn = new SqlConnection(conn_path);
        private static SqlCommand cmd;
        private static SqlDataReader reader;

        public static bool UserExist(string user)
        {
            bool ok = false;

            conn.Open();

            cmd = new SqlCommand($"SELECT * FROM Utilizatori WHERE NumeUtilizator = '{user}';", conn);

            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                ok = true;
            }

            reader.Close();
            conn.Close();

            return ok;
        }

        public static void NewUser(string user, string parola)
        {
            conn.Open();

            cmd = new SqlCommand($"INSERT INTO Utilizatori(NumeUtilizator, Parola, Credite) VALUES('{user}', '{parola}', '0');", conn);

            cmd.ExecuteNonQuery();
            conn.Close();

            int id = baza.GetId(user);

            conn.Open();

            cmd = new SqlCommand($"INSERT INTO Setari(IdUtilizator, CuloareSarpe, VitezaSarpe, ImagineFundal) VALUES('{id}', 'default', '1', '1')", conn);

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand($"INSERT INTO Vanzari(IdUtilizator, CuloareSarpe) VALUES('{id}', 'default');", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static bool PassOk(string inpass, string user)
        {
            string okpass;

            conn.Open();

            cmd = new SqlCommand($"SELECT Parola FROM Utilizatori WHERE NumeUtilizator = '{user}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            okpass = reader[0].ToString();

            reader.Close();
            conn.Close();

            return okpass == inpass;
        }

        public static void InitDgvScor(DataGridView dgvScor)
        {
            dgvScor.Rows.Clear();

            conn.Open();

            cmd = new SqlCommand($"SELECT TOP 5 IdUtilizator, MAX(Scor) as Scor FROM Scoruri GROUP BY IdUtilizator ORDER BY MAX(Scor) DESC;", conn);

            reader = cmd.ExecuteReader();

            int[] ids = new int[6];
            int[] scors = new int[6];

            int index = 0;

            while(reader.Read())
            {
                int id = Convert.ToInt32(reader[0].ToString());
                int scor = Convert.ToInt32(reader[1].ToString());

                ids[++index] = id;
                scors[index] = scor;
            }

            reader.Close();
            conn.Close();

            for(int i=1;i<=index;i++)
            {
                string user = baza.GetUser(ids[i]);

                dgvScor.Rows.Add(user, scors[i]);
            }
        }

        public static void InitDgvBani(DataGridView dgvBani)
        {
            dgvBani.Rows.Clear();

            conn.Open();

            cmd = new SqlCommand($"SELECT TOP 5 * FROM Utilizatori ORDER BY Credite DESC;", conn);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string user = reader[1].ToString();
                int credite = Convert.ToInt32(reader[3].ToString());

                dgvBani.Rows.Add(user, credite);
            }

            reader.Close();
            conn.Close();
        }

        public static int GetId(string user)
        {
            int id;

            conn.Open();

            cmd = new SqlCommand($"SELECT IdUtilizator FROM Utilizatori WHERE NumeUtilizator = '{user}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            id = Convert.ToInt32(reader[0].ToString());

            reader.Close();
            conn.Close();

            return id;
        }

        public static string GetUser(int id)
        {
            string user;

            conn.Open();

            cmd = new SqlCommand($"SELECT NumeUtilizator FROM Utilizatori WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            user = reader[0].ToString();

            reader.Close();
            conn.Close();

            return user;
        }

        public static int GetMaxScore(int id)
        {
            bool ok = false;

            int score = 0;

            conn.Open();

            cmd = new SqlCommand($"SELECT Scor FROM Scoruri WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                ok = true;
            }

            reader.Close();
            conn.Close();

            if(ok)
            {
                conn.Open();

                cmd = new SqlCommand($"SELECT MAX(Scor) FROM Scoruri WHERE IdUtilizator = '{id}';", conn);

                reader = cmd.ExecuteReader();

                reader.Read();

                score = Convert.ToInt32(reader[0].ToString());

                reader.Close();
                conn.Close();
            }

            return score;
        }

        public static string GetPass(int id)
        {
            string pass;

            conn.Open();

            cmd = new SqlCommand($"SELECT Parola FROM Utilizatori WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            pass = reader[0].ToString();

            reader.Close();
            conn.Close();

            return pass;
        }

        public static int GetCredits(int id)
        {
            int credite;

            conn.Open();

            cmd = new SqlCommand($"SELECT Credite FROM Utilizatori WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            credite = Convert.ToInt32(reader[0].ToString());

            reader.Close();
            conn.Close();

            return credite;
        }

        public static void UpdateUser(string newUser, int id)
        {
            conn.Open();

            cmd = new SqlCommand($"UPDATE Utilizatori SET NumeUtilizator = '{newUser}' WHERE IdUtilizator = '{id}';", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static string GetSetareCuloare(int id)
        {
            string culoare = "default";

            conn.Open();

            cmd = new SqlCommand($"SELECT CuloareSarpe FROM Setari WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            culoare = reader[0].ToString();

            reader.Close();
            conn.Close();

            return culoare;
        }

        public static int GetSetareViteza(int id)
        {
            int viteza = 1;

            conn.Open();

            cmd = new SqlCommand($"SELECT VitezaSarpe FROM Setari WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            viteza = Convert.ToInt32(reader[0].ToString());

            reader.Close();
            conn.Close();

            return viteza;
        }

        public static int GetSetareFundal(int id)
        {
            int fundal = 1;

            conn.Open();

            cmd = new SqlCommand($"SELECT ImagineFundal FROM Setari WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            reader.Read();

            fundal = Convert.ToInt32(reader[0].ToString());

            reader.Close();
            conn.Close();

            return fundal;
        }

        public static void InitCmbColor(ComboBox cmbColorSnake, int id)
        {
            cmbColorSnake.Items.Clear();

            conn.Open();

            cmd = new SqlCommand($"SELECT CuloareSarpe FROM Vanzari WHERE IdUtilizator = '{id}';", conn);

            reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                string culoare = reader[0].ToString();

                cmbColorSnake.Items.Add(culoare);
            }

            reader.Close();

            conn.Close();
        }

        public static void UpdateSettings(int id, string culoare, int viteza, int fundal)
        {
            conn.Open();

            cmd = new SqlCommand($"UPDATE Setari SET CuloareSarpe = '{culoare}', VitezaSarpe = '{viteza}', ImagineFundal = '{fundal}' WHERE IdUtilizator = '{id}';", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void NewPurchase(string tag, int id, int credite)
        {
            conn.Open();

            cmd = new SqlCommand($"INSERT INTO Vanzari(IdUtilizator, CuloareSarpe) VALUES('{id}', '{tag}');", conn);

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand($"UPDATE Utilizatori SET Credite = '{credite}' WHERE IdUtilizator = '{id}';", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void NewScore(int id, int score)
        {
            conn.Open();

            cmd = new SqlCommand($"INSERT INTO Scoruri(IdUtilizator, Scor) VALUES('{id}', '{score}');", conn);

            cmd.ExecuteNonQuery();

            conn.Close();

            int credite = baza.GetCredits(id);

            credite = credite + score / 2;

            conn.Open();

            cmd = new SqlCommand($"UPDATE Utilizatori SET Credite = '{credite}' WHERE IdUtilizator = '{id}';", conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
