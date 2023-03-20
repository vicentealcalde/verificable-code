using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Escrituras.pages.Escritura
{
    
    public class IndexModel : PageModel
    {
        public List<Escritura> listescritura = new List<Escritura>();
        public void OnGet() {
            try 
            {
                String connectionString = "Data Source=.\\SQLEXPRESS02;Initial Catalog=Escrituras;Integrated Security=True";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    String sql = "SELECT * FROM escritura";
                    using (SqlCommand command = new SqlCommand(sql, sqlConnection)) 
                    {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                        while (reader.Read())
                            {
                            Escritura escritura = new Escritura();
                            escritura.NumAtencion = reader.GetString(0);
                            escritura.CNE = reader.GetString(1);
                            escritura.Comuna = reader.GetString(2);   
                            escritura.Manzana = reader.GetString(3);
                            escritura.Predio = reader.GetString(4);
                            escritura.Fojas = reader.GetString(5);
                            escritura.FechaInscripcion = reader.GetString(6);
                            escritura.NumeroInscripcion = reader.GetString(7);

                             listescritura.Add(escritura);
                            }
                        }
                    }
                }
            
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

        } 
    
    }

    public class Escritura
    {
        public String NumAtencion;
        public String CNE;
        public String Comuna;
        public String Manzana;
        public String Predio;
        public String Fojas;
        public String FechaInscripcion;
        public String NumeroInscripcion;
    }
}
