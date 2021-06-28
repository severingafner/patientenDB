using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Zusätzlicher Namespace
using System.Data.SqlClient;

//using System.Data.OleDb;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace patientDB.DBConnection
{
    public class DBConnection
    {
        //Connection string
        //--> Access --> static string conn_str = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\TEMP\\Zugriff_c#.mdb";

        string conn_str = "Data Source = DESKTOP-8K0P1B4\\SQLEXPRESS;" + "Initial Catalog = Test_SP;" + "Integrated Security=SSPI;";

        //Dataset definieren
        DataSet my_ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        //Methode zur Demonstration des DB-Zugriffes
        private void button1_Click(object sender, EventArgs e)
        {
            //Oledb connection objekt
            SqlConnection my_conn = new SqlConnection(conn_str);

            //Versuchen auf die DB zuzugreifen
            try
            {
                //Erfolgreich
                //Zugriff physisch
                my_conn.Open();

                //Erfolgsmeldung
                MessageBox.Show("Alles klar");
            }
            catch (Exception ex)
            {
                //Nicht erfolgreich
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Schliessen
                my_conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Oledb connection objekt
            SqlConnection my_conn = new SqlConnection(conn_str);

            //Versuchen auf die DB zuzugreifen
            try
            {
                //Erfolgreich
                //Zugriff physisch
                my_conn.Open();

                //Zusätzlicher Code

                //dataadaptor füllen
                SqlDataAdapter my_da = new SqlDataAdapter("SELECT * FROM Erste_Tabelle", my_conn);
                //dataset füllen
                my_da.Fill(my_ds, "mein_ds");

                //Erfolgsmeldung
                MessageBox.Show("Alles klar");
            }
            catch (Exception ex)
            {
                //Nicht erfolgreich
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Schliessen
                my_conn.Close();
            }

        }

        //Methode zum Anzeigen
        private void button3_Click(object sender, EventArgs e)
        {
            //Nutzen des DataSets
            //Umwandeln in DataTable
            DataTable my_dt = my_ds.Tables["mein_ds"];

            //Auslesen der DataTable
            foreach (DataRow my_dr in my_dt.Rows)
            {
                //Auslesen des Feldes Inhalt aus der DB
                textBox1.Text += my_dr["Inhalt"] + System.Environment.NewLine;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Connection aufbauen
            SqlConnection my_conn = new SqlConnection(conn_str);


            //Befehlsstring
            string my_sql = "INSERT INTO Erste_Tabelle (Inhalt) VALUES ('vier')";

            //Commandobjekt bilden
            SqlCommand my_cmd = new SqlCommand(my_sql, my_conn);

            try
            {
                //Connection öffnen
                my_conn.Open();

                //Befehl abschicken
                my_cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Fehlermeldung
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //DB-Connection schliessen
                my_conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Connection aufbauen
            SqlConnection my_conn = new SqlConnection(conn_str);

            //Befehlsstring
            string my_sql = "DELETE FROM Erste_Tabelle WHERE Inhalt = 'vier'";

            //Commandobjekt bilden
            SqlCommand my_cmd = new SqlCommand(my_sql, my_conn);

            try
            {
                //Connection öffnen
                my_conn.Open();

                //Befehl abschicken
                my_cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Fehlermeldung
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //DB-Connection schliessen
                my_conn.Close();
            }
        }
    }
}
