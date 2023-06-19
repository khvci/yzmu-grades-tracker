using System.Data;
using yzmu_grades_tracker_API;

namespace yzmu_grades_tracker_UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            timer1.Interval = 900000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                FetchInfo();
            }
            else
            {
                MessageBox.Show("Öğrenci no ve parola girmek lazım.");
            }
        }

        private void FetchInfo()
        {
            PageNavigator PageNavigator = new PageNavigator();

            try
            {
                PageNavigator.Login(txtUsername.Text, txtPassword.Text);
                Thread.Sleep(5000);
                PageNavigator.NavigateToInfoPage();
                PageNavigator.NavigateToCoursesPage();
                PageNavigator.FocusOnNewTab();
                PageNavigator.IterateThroughCourses();

                DataTable dt = new DataTable();
                dt.Columns.Add("Ders", typeof(string));
                dt.Columns.Add("Vize", typeof(string));
                dt.Columns.Add("Final", typeof(string));

                foreach (Course course in PageNavigator.CoursesList)
                {
                    dt.Rows.Add(new object[] { course.CourseName, course.MidTerm, course.Final });
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                PageNavigator.QuitSession();
                MessageBox.Show("Bir hata oldu. 30 dakika sonra tekrar denenecek.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnLogin.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //https://github.com/khvci/yzmu-grades-tracker
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageNavigator navigator = new PageNavigator();
            navigator.GoToGithub();
        }
    }
}
