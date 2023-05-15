namespace ManagmentOfProducts
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Button currentButton;
        public Form activeForm;



        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                DisableButton();
                if (currentButton != (Button)btnSender)
                {
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.Black;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }


        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Maroon;
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, FontStyle.Bold, GraphicsUnit.Point);

                }
            }
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelForm.Controls.Add(childForm);
            this.panelForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;


        }

        private void btnWinesMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.WinesForm(), sender);
        }

        private void btnCollectionsMenu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnAccessoriesMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AccessoryForm(), sender);
        }

        private void btnUsersMenu_Click(object sender, EventArgs e)
        {
           OpenChildForm(new Forms.UserForm(), sender);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWineCellerMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.WineCellersForm(), sender);
        }
    }
}