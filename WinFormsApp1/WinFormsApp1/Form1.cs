namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private User userData;
        private string path;
        public Form1()
        {
            InitializeComponent();
            userData = new User();
            path = userData.filePath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userData.LoadUsersFromJson(path);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (userData.IsValid(username, password))
            {
                label3.Text = "Login successful!";
                label3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label3.Text = "Invalid username or password.";
                label3.ForeColor = System.Drawing.Color.Red;
            }
            label3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text;
            string password = textBox4.Text;
            try
            {
                userData.AddUser(username, password, path);
                label6.Visible= true;
                label6.Text = "Account Created Successfully";
            }
            catch
            {
                label6.Text = "Account Already Exist";
                label6.Visible = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }
    }
}
