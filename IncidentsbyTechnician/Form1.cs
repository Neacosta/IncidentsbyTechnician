using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncidentsbyTechnician
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Technician> technicianNames = TechnicianDB.GetTechnicians();
            List<Incident> incidents = IncidentDB.GetIncidents();

            var result = from incident in incidents
                         join t in technicianNames
                         on incident.TechID equals t.TechID
                         where incident.DateClosed != null
                         //orderby incident.DateOpened, t.Name
                         select new
                         {
                             t.Name,
                             incident.ProductCode,
                             incident.DateOpened,
                             incident.DateClosed,
                             incident.Title
                             

                         };
            string technicianName = "";
            int i = 0;
            foreach (var r in result)
            {
                if(r.Name != technicianName)
                {
                    lvIncidents.Items.Add(r.Name);
                    technicianName = r.Name;
                   

                }
                else
                {
                    lvIncidents.Items.Add("");
                }

                lvIncidents.Items[i].SubItems.Add(r.ProductCode.ToString());
                lvIncidents.Items[i].SubItems.Add(r.DateOpened.ToShortDateString());
                lvIncidents.Items[i].SubItems.Add(r.DateClosed.ToString());
                lvIncidents.Items[i].SubItems.Add(r.Title.ToString());
                i += 1;
            }
            
        }
    }
}
