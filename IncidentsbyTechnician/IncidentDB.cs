using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace IncidentsbyTechnician
{
    public static class IncidentDB
    {
        private const string directory = @"C:\Users\nelso\Downloads\";
        private const string path = directory + "Incidents.Txt";

        public static List<Incident> GetIncidents()
        {
            List<Incident> incidentsList = new List<Incident>();

            StreamReader textIn = new StreamReader(
                                 new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string [] columns = row.Split('|');
                Incident incidents = new Incident();
                incidents.ProductCode = columns[2];
               
                Int32.TryParse(columns[3], out var ID);
                if (ID == 0)
                {
                    incidents.TechID = null;

                }
                else
                {
                    incidents.TechID = ID;

                }

                incidents.DateOpened = Convert.ToDateTime(columns[4]);
                DateTime.TryParse((columns[5]), out var date);
                if (date == null)
                {
                    incidents.DateClosed = null;

                }
                else
                {
                    incidents.DateClosed = date;

                }
               
                incidents.Title = columns[6];

                incidentsList.Add(incidents);

            }
            textIn.Close();
            return incidentsList;

                        
            
        }


    }
}
