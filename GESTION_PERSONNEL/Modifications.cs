using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raven.Client.Documents;
using static GESTION_PERSONNEL.Enregistrement;


namespace GESTION_PERSONNEL
{
    public partial class Modifications : Form
    {
        public Modifications()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
        }
     

        private void guna2ControlBox4_Click(object sender, EventArgs e)
        {

        }

        private void Modifications_Load(object sender, EventArgs e)
        {
            Actions action = new Actions();
                action.ModifierEmploye();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            using (var store = new DocumentStore
            {
                Urls = new[] { "http://localhost:8080" },
                Database = "DB_PERSONNEL"
            })
            {
                store.Initialize();

                // Ouvrir une session RavenDB
                using (var session = store.OpenSession())
                {
                    // Récupérer l'employé à modifier
                    var employeAModifier = session.Load<Employe>(txtNom.Text);

                    // Mettre à jour les propriétés de l'employé
                    employeAModifier.Nom = txtNom.Text;
                    employeAModifier.Prenom = txtPrenom.Text;
                    employeAModifier.Poste = cmbPoste.Text;
                    employeAModifier.Sexe = cmbSexe.Text;
                    employeAModifier.dateNaiss = dataTime.Text;
                    employeAModifier.Salaire = 400;

                    // Enregistrer les modifications dans la base de données
                    session.SaveChanges();
                }
            }



        }
    }
}
