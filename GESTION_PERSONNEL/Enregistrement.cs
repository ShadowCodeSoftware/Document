using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GESTION_PERSONNEL
{
    public partial class Enregistrement : Form
    {
        public Enregistrement()
        {
            InitializeComponent();
        }
        // pour creer un constructeur
        internal class Employe
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Poste { get; set; }
            public string dateNaiss { get; set; }
            public string Sexe { get; set; }
            public int Salaire { get; set; }
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

                // Créer une nouvelle session RavenDB
                using (var session = store.OpenSession())
                {
                    // Créer un nouvel employé
                    var nouvelEmploye = new Employe
                    {
                        Nom = txtNom.Text,
                        Prenom = txtPrenom.Text,
                        Poste = cmbPoste.Text,
                        Sexe = cmbSexe.Text,
                        dateNaiss = dataTime.Text,                       
                        Salaire = 400
                    };

                    // Ajouter le nouvel employé à la base de données
                    session.Store(nouvelEmploye);
                    session.SaveChanges();
                }
            }
            MessageBox.Show("Ajouté avec succes");
            txtNom.Text = "";
            txtPrenom.Text = "";
            cmbPoste.Text = "";
            cmbSexe.Text = "";
            txtSalaire.Text = "";
            dataTime.Text = "";
        }

        private void Enregistrement_Load(object sender, EventArgs e)
        {

        }
    }
}
