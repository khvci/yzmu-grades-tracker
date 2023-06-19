using yzmu_grades_tracker_API;

namespace yzmu_grades_tracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //PageNavigator.Login(txtUsername.Text, txtPassword.Text);
            PageNavigator.Login("Y220240068", "DULUO.kilop.4656");
            Thread.Sleep(2000);
            PageNavigator.NavigateToInfoPage();
            PageNavigator.NavigateToCoursesPage();
            PageNavigator.FocusOnNewTab();
            PageNavigator.IterateThroughCourses();
            Thread.Sleep(2000);

            List<Course> list = PageNavigator.CoursesList;
            MessageBox.Show(list[0].CourseName);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}