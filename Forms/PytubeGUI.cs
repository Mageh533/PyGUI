namespace PytubeGUI
{
    public partial class PytubeGUI : Form
    {
        private string url = "";

        public PytubeGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Downloading: " + url);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            url = textBox1.Text;
        }
    }
}
