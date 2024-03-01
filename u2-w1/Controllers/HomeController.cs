using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u2_w1.Models;

namespace u2_w1.Controllers
{
    public class HomeController : Controller
    {
        // ottenere l'elenco degli anagrafica
        [HttpGet]
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            List<Anagrafica> listAnagrafica = new List<Anagrafica>();

            try
            {

                string query = "SELECT * FROM Anagrafica";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Anagrafica anagrafica = new Anagrafica();
                    anagrafica.IdAnagrafica = Convert.ToInt32(reader["IdAnagrafica"]);
                    anagrafica.Cognome = reader["Cognome"].ToString();
                    anagrafica.Nome = reader["Nome"].ToString();
                    anagrafica.Indirizzo = reader["Indirizzo"].ToString();
                    anagrafica.Citta = reader["Citta"].ToString();
                    anagrafica.CAP = reader["CAP"].ToString();
                    anagrafica.CF = reader["CF"].ToString();
                    listAnagrafica.Add(anagrafica);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(listAnagrafica);
        }

       public ActionResult CreateTras() {             return View();
               }
        // POST: Create - Aggiungi anagrafica
        [HttpPost]
        public ActionResult CreateTras(Anagrafica anagrafica)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CF) VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @CF)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                cmd.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                cmd.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                cmd.Parameters.AddWithValue("@Citta", anagrafica.Citta);
                cmd.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                cmd.Parameters.AddWithValue("@CF", anagrafica.CF);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]

        // GET: Update - Modifica anagrafica
        public ActionResult UpdateTras(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            Anagrafica anagrafica = new Anagrafica();
            try
            {
                string query = "SELECT * FROM Anagrafica WHERE IdAnagrafica = @IdAnagrafica";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdAnagrafica", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    anagrafica.IdAnagrafica = Convert.ToInt32(reader["IdAnagrafica"]);
                    anagrafica.Cognome = reader["Cognome"].ToString();
                    anagrafica.Nome = reader["Nome"].ToString();
                    anagrafica.Indirizzo = reader["Indirizzo"].ToString();
                    anagrafica.Citta = reader["Citta"].ToString();
                    anagrafica.CAP = reader["CAP"].ToString();
                    anagrafica.CF = reader["CF"].ToString();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(anagrafica);
        }
        [HttpPost]
        public ActionResult UpdateTras(Anagrafica anagrafica)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE Anagrafica SET Cognome = @Cognome, Nome = @Nome, Indirizzo = @Indirizzo, Citta = @Citta, CAP = @CAP, CF = @CF WHERE IdAnagrafica = @IdAnagrafica";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdAnagrafica", anagrafica.IdAnagrafica);
                cmd.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                cmd.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                cmd.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                cmd.Parameters.AddWithValue("@Citta", anagrafica.Citta);
                cmd.Parameters.AddWithValue("@CAP", anagrafica.CAP);
                cmd.Parameters.AddWithValue("@CF", anagrafica.CF);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }


        // GET: Delete - Elimina anagrafica
        public ActionResult DeleteTras(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "DELETE FROM Anagrafica WHERE IdAnagrafica = @IdAnagrafica";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdAnagrafica", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Index");
        }


        // GET: TipoVio - Visualizza violazioni
        [HttpGet]
        public ActionResult TipoVio()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            List<TipoViolazione> listViolazione = new List<TipoViolazione>();

            try
            {
                //query per selezionare tutte le violazioni dalla tabella TipoViolazione
                string query = "SELECT * FROM TipoViolazione WHERE Contestabile = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoViolazione violazione = new TipoViolazione();
                    violazione.IdViolazione = Convert.ToInt32(reader["IdViolazione"]);
                    violazione.Descrizione = reader["Descrizione"].ToString();
                    violazione.Contestabile = Convert.ToBoolean(reader["Contestabile"]);
                    listViolazione.Add(violazione);
                }
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return View(listViolazione);
        }

        // GET: Create - Aggiungi violazione

        public ActionResult CreateVio()
        {
            return View();
        }

        // POST: Create - Aggiungi violazione

        [HttpPost]
        public ActionResult CreateVio(TipoViolazione violazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                //query per inserire una nuova violazione nella tabella TipoViolazione
                string query = "INSERT INTO TipoViolazione (Descrizione, Contestabile) VALUES (@Descrizione, @Contestabile)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Descrizione", violazione.Descrizione);
                cmd.Parameters.AddWithValue("@Contestabile", violazione.Contestabile);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return RedirectToAction("Index");
        }


        // GET: Update - Modifica violazione
        [HttpGet]

        public ActionResult UpdateVio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            TipoViolazione violazione = new TipoViolazione();
            try
            {
                string query = "SELECT * FROM TipoViolazione WHERE IdViolazione = @IdViolazione";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdViolazione", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    violazione.IdViolazione = Convert.ToInt32(reader["IdViolazione"]);
                    violazione.Descrizione = reader["Descrizione"].ToString();
                    violazione.Contestabile = Convert.ToBoolean(reader["Contestabile"]);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(violazione);
        }

        [HttpPost]

        public ActionResult UpdateVio(TipoViolazione violazione)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE TipoViolazione SET Descrizione = @Descrizione, Contestabile = @Contestabile WHERE IdViolazione = @IdViolazione";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdViolazione", violazione.IdViolazione);
                cmd.Parameters.AddWithValue("@Descrizione", violazione.Descrizione);
                cmd.Parameters.AddWithValue("@Contestabile", violazione.Contestabile);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("TipoVio");
        }


        // GET: Delete - Elimina violazione
        public ActionResult DeleteVio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "DELETE FROM TipoViolazione WHERE IdViolazione = @IdViolazione";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdViolazione", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("TipoVio");
        }


        public ActionResult Verb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            List<Verbale> listVerbale = new List<Verbale>();

            try
            {
                //query per selezionare tutti i verbali dalla tabella Verbale
                string query = "SELECT * FROM Verbale";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Verbale verbale = new Verbale();
                    verbale.IdVerbale = Convert.ToInt32(reader["IdVerbale"]);
                    verbale.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    verbale.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    verbale.NominativoAgente = reader["NominativoAgente"].ToString();
                    verbale.DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    verbale.Importo = Convert.ToDecimal(reader["Importo"]);
                    verbale.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    verbale.IdAnagrafica = Convert.ToInt32(reader["IdAnagrafica"]);
                    verbale.IdViolazione = Convert.ToInt32(reader["IdViolazione"]);
                    listVerbale.Add(verbale);
                }
            }

            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return View(listVerbale);
        }

        // GET: Create - Aggiungi verbale

        public ActionResult CreateVerb()
        {
            return View();
        }

        // POST: Create - Aggiungi verbale

        [HttpPost]
        public ActionResult CreateVerb(Verbale verbale)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                //query per inserire un nuovo verbale nella tabella Verbale
                string query = "INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagrafica, IdAiolazione) VALUES (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @IdAnagrafica, @IdViolazione)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);
                cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return RedirectToAction("Verb");
        }


        // GET: Update - Modifica verbale

        [HttpGet]
        public ActionResult UpdateVerb(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            Verbale verbale = new Verbale();
            try
            {
                string query = "SELECT * FROM Verbale WHERE IdVerbale = @IdVerbale";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdVerbale", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    verbale.IdVerbale = Convert.ToInt32(reader["IdVerbale"]);
                    verbale.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    verbale.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    verbale.NominativoAgente = reader["NominativoAgente"].ToString();
                    verbale.DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    verbale.Importo = Convert.ToDecimal(reader["Importo"]);
                    verbale.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    verbale.IdAnagrafica = Convert.ToInt32(reader["IdAnagrafica"]);
                    verbale.IdViolazione = Convert.ToInt32(reader["IdViolazione"]);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(verbale);
        }

        [HttpPost]

        public ActionResult UpdateVerb(Verbale verbale)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "UPDATE Verbale SET DataViolazione = @DataViolazione, IndirizzoViolazione = @IndirizzoViolazione, NominativoAgente = @NominativoAgente, DataTrascrizioneVerbale = @DataTrascrizioneVerbale, Importo = @Importo, DecurtamentoPunti = @DecurtamentoPunti, IdAnagrafica = @IdAnagrafica, IdViolazione = @IdViolazione WHERE IdVerbale = @IdVerbale";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdVerbale", verbale.IdVerbale);
                cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);
                cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Verb");
        }

        // GET: Delete - Elimina verbale
        public ActionResult DeleteVerb(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "DELETE FROM Verbale WHERE IdVerbale = @IdVerbale";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IdVerbale", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("Verb");
        }







    }










}