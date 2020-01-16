using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IncidentsbyTechnician
{
    class TechnicianDB
    {
        private const string directory = @"C:\Users\nelso\Downloads\";
        private const string path = directory + "Technicians.Txt";

        public static List<Technician> GetTechnicians()
        {
            List<Technician> techsList = new List<Technician>();

            StreamReader textIn = new StreamReader(
                                    new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string [] columns = row.Split('|');
                Technician technician = new Technician();
                technician.Name = columns[1];
                technician.TechID = Convert.ToInt32(columns[0]);
                techsList.Add(technician);
            }
            textIn.Close();
            return techsList;

        }
        
    }
}
