using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GESTION_PERSONNEL.Enregistrement;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace GESTION_PERSONNEL
{
    public partial class Actions : Form
    {
        public Actions()
        {
            InitializeComponent();
        }

        new void Select()
        {
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
            check.Name = "selectionner";
            DataGridView1.Columns.Add(check);
           
        }
       

        void afficher()
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
                    // Récupérer tous les employés de la base de données
                    var employes = session.Query<Employe>().ToList();

                    // Afficher les employés dans le tableau
                    DataGridView1.DataSource = employes;
                }
            }
        }

        private void Actions_Load(object sender, EventArgs e)
        {
            Select();
            afficher();
        }
        public void ModifierEmploye()
        {

            foreach (DataGridViewRow r in DataGridView1.Rows)
            {
                try
                {
                    if (Convert.ToBoolean(r.Cells["Selectionner"].Value) == true)
                    {
                        Modifications E = new Modifications();
                        E.Show();
                        E.txtNom.Text = r.Cells["Nom"].Value.ToString();
                        E.txtNom.Text = r.Cells["Nom"].Value.ToString();
                        E.txtPrenom.Text = r.Cells["Prenom"].Value.ToString();
                        E.cmbPoste.Text = r.Cells["Poste"].Value.ToString();
                        E.cmbSexe.Text = r.Cells["Sexe"].Value.ToString();
                        E.dataTime.Text = r.Cells["dateNaiss"].Value.ToString();
                        E.txtSalaire.Text = r.Cells["Salaire"].Value.ToString();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public void Supprimer()
        {

            foreach (DataGridViewRow r in DataGridView1.Rows)
            {
                try
                {
                    if (Convert.ToBoolean(r.Cells["Selectionner"].Value) == true)
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
                                // Récupérer l'employé à supprimer
                                var employeASupprimer = session.Load<Employe>(Name);

                                // Supprimer l'employé de la base de données
                                session.Delete(employeASupprimer);
                                session.SaveChanges();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }



        private void btnModifier_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = DataGridView1.SelectedRows[0];
            Modifications en = new Modifications();
             ModifierEmploye();          
        }
        public void SupprimerEmploye(string Id)
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
                    // Récupérer l'employé à supprimer
                    var employeASupprimer = session.Load<Employe>(Id);

                    // Supprimer l'employé de la base de données
                    session.Delete(employeASupprimer);
                    session.SaveChanges();
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            Supprimer();
        }
    }
}
