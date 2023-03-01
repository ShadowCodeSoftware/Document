namespace GESTION_PERSONNEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnregistrement_Click(object sender, EventArgs e)
        {
            panelTitre.Visible = false;
            Enregistrement en = new Enregistrement();
            en.ShowDialog();
            
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            panelTitre.Visible = false;
            Actions act = new Actions();
            act.ShowDialog();
            
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAcceuil_Click(object sender, EventArgs e)
        {
            panelTitre.Visible = true;
        }
    }
}