using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace TestUIWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            //Create DataGrid Items Info
            members.Add(new Member { Number = "1", Character = "J", bgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Coach", Email = "john.doe@gmail.com", Phone = "496-846-125" });
            members.Add(new Member { Number = "2", Character = "R", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Reza Alavi", Position = "Administrator", Email = "reza11@hotmail.com", Phone = "476-246-165" });
            members.Add(new Member { Number = "3", Character = "D", bgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Dennis Castillo", Position = "Coach", Email = "dent.cast@@gmail.com", Phone = "456-349-425" });
            members.Add(new Member { Number = "4", Character = "G", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Gabriel Cox", Position = "Coach", Email = "coxcox@gmail.com", Phone = "652-462-115" });
            members.Add(new Member { Number = "5", Character = "L", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lena Jones", Position = "Manager", Email = "len.off@hotmail.com", Phone = "454-843-185" });
            members.Add(new Member { Number = "6", Character = "B", bgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Benjamin Caliword", Position = "Administrator", Email = "beni12@hotmail.com", Phone = "456-846-325" });
            members.Add(new Member { Number = "7", Character = "S", bgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Sophia Muris", Position = "Coach", Email = "sophi.muri@gmail.com", Phone = "476-449-129" });
            members.Add(new Member { Number = "8", Character = "A", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Ali Pormand", Position = "Manager", Email = "aliport@yahoo.com", Phone = "456-866-126" });
            members.Add(new Member { Number = "9", Character = "F", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Frank Underwood", Position = "Manager", Email = "frank@yahoo.com", Phone = "358-866-423" });
            members.Add(new Member { Number = "10", Character = "S", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Saeed Dasman", Position = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "436-846-129" });

            members.Add(new Member { Number = "1", Character = "J", bgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Coach", Email = "john.doe@gmail.com", Phone = "496-846-125" });
            members.Add(new Member { Number = "2", Character = "R", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Reza Alavi", Position = "Administrator", Email = "reza11@hotmail.com", Phone = "476-246-165" });
            members.Add(new Member { Number = "3", Character = "D", bgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Dennis Castillo", Position = "Coach", Email = "dent.cast@@gmail.com", Phone = "456-349-425" });
            members.Add(new Member { Number = "4", Character = "G", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Gabriel Cox", Position = "Coach", Email = "coxcox@gmail.com", Phone = "652-462-115" });
            members.Add(new Member { Number = "5", Character = "L", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lena Jones", Position = "Manager", Email = "len.off@hotmail.com", Phone = "454-843-185" });
            members.Add(new Member { Number = "6", Character = "B", bgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Benjamin Caliword", Position = "Administrator", Email = "beni12@hotmail.com", Phone = "456-846-325" });
            members.Add(new Member { Number = "7", Character = "S", bgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Sophia Muris", Position = "Coach", Email = "sophi.muri@gmail.com", Phone = "476-449-129" });
            members.Add(new Member { Number = "8", Character = "A", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Ali Pormand", Position = "Manager", Email = "aliport@yahoo.com", Phone = "456-866-126" });
            members.Add(new Member { Number = "9", Character = "F", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Frank Underwood", Position = "Manager", Email = "frank@yahoo.com", Phone = "358-866-423" });
            members.Add(new Member { Number = "10", Character = "S", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Saeed Dasman", Position = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "436-846-129" });

            members.Add(new Member { Number = "1", Character = "J", bgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Coach", Email = "john.doe@gmail.com", Phone = "496-846-125" });
            members.Add(new Member { Number = "2", Character = "R", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Reza Alavi", Position = "Administrator", Email = "reza11@hotmail.com", Phone = "476-246-165" });
            members.Add(new Member { Number = "3", Character = "D", bgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Dennis Castillo", Position = "Coach", Email = "dent.cast@@gmail.com", Phone = "456-349-425" });
            members.Add(new Member { Number = "4", Character = "G", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Gabriel Cox", Position = "Coach", Email = "coxcox@gmail.com", Phone = "652-462-115" });
            members.Add(new Member { Number = "5", Character = "L", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lena Jones", Position = "Manager", Email = "len.off@hotmail.com", Phone = "454-843-185" });
            members.Add(new Member { Number = "6", Character = "B", bgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Benjamin Caliword", Position = "Administrator", Email = "beni12@hotmail.com", Phone = "456-846-325" });
            members.Add(new Member { Number = "7", Character = "S", bgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Sophia Muris", Position = "Coach", Email = "sophi.muri@gmail.com", Phone = "476-449-129" });
            members.Add(new Member { Number = "8", Character = "A", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Ali Pormand", Position = "Manager", Email = "aliport@yahoo.com", Phone = "456-866-126" });
            members.Add(new Member { Number = "9", Character = "F", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Frank Underwood", Position = "Manager", Email = "frank@yahoo.com", Phone = "358-866-423" });
            members.Add(new Member { Number = "10", Character = "S", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Saeed Dasman", Position = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "436-846-129" });

            members.Add(new Member { Number = "1", Character = "J", bgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Coach", Email = "john.doe@gmail.com", Phone = "496-846-125" });
            members.Add(new Member { Number = "2", Character = "R", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Reza Alavi", Position = "Administrator", Email = "reza11@hotmail.com", Phone = "476-246-165" });
            members.Add(new Member { Number = "3", Character = "D", bgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Dennis Castillo", Position = "Coach", Email = "dent.cast@@gmail.com", Phone = "456-349-425" });
            members.Add(new Member { Number = "4", Character = "G", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Gabriel Cox", Position = "Coach", Email = "coxcox@gmail.com", Phone = "652-462-115" });
            members.Add(new Member { Number = "5", Character = "L", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lena Jones", Position = "Manager", Email = "len.off@hotmail.com", Phone = "454-843-185" });
            members.Add(new Member { Number = "6", Character = "B", bgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Benjamin Caliword", Position = "Administrator", Email = "beni12@hotmail.com", Phone = "456-846-325" });
            members.Add(new Member { Number = "7", Character = "S", bgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Sophia Muris", Position = "Coach", Email = "sophi.muri@gmail.com", Phone = "476-449-129" });
            members.Add(new Member { Number = "8", Character = "A", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Ali Pormand", Position = "Manager", Email = "aliport@yahoo.com", Phone = "456-866-126" });
            members.Add(new Member { Number = "9", Character = "F", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Frank Underwood", Position = "Manager", Email = "frank@yahoo.com", Phone = "358-866-423" });
            members.Add(new Member { Number = "10", Character = "S", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Saeed Dasman", Position = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "436-846-129" });

            members.Add(new Member { Number = "1", Character = "J", bgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Coach", Email = "john.doe@gmail.com", Phone = "496-846-125" });
            members.Add(new Member { Number = "2", Character = "R", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Reza Alavi", Position = "Administrator", Email = "reza11@hotmail.com", Phone = "476-246-165" });
            members.Add(new Member { Number = "3", Character = "D", bgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Dennis Castillo", Position = "Coach", Email = "dent.cast@@gmail.com", Phone = "456-349-425" });
            members.Add(new Member { Number = "4", Character = "G", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Gabriel Cox", Position = "Coach", Email = "coxcox@gmail.com", Phone = "652-462-115" });
            members.Add(new Member { Number = "5", Character = "L", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lena Jones", Position = "Manager", Email = "len.off@hotmail.com", Phone = "454-843-185" });
            members.Add(new Member { Number = "6", Character = "B", bgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Benjamin Caliword", Position = "Administrator", Email = "beni12@hotmail.com", Phone = "456-846-325" });
            members.Add(new Member { Number = "7", Character = "S", bgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Sophia Muris", Position = "Coach", Email = "sophi.muri@gmail.com", Phone = "476-449-129" });
            members.Add(new Member { Number = "8", Character = "A", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Ali Pormand", Position = "Manager", Email = "aliport@yahoo.com", Phone = "456-866-126" });
            members.Add(new Member { Number = "9", Character = "F", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Frank Underwood", Position = "Manager", Email = "frank@yahoo.com", Phone = "358-866-423" });
            members.Add(new Member { Number = "10", Character = "S", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Saeed Dasman", Position = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "436-846-129" });

            members.Add(new Member { Number = "1", Character = "J", bgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "John Doe", Position = "Coach", Email = "john.doe@gmail.com", Phone = "496-846-125" });
            members.Add(new Member { Number = "2", Character = "R", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Reza Alavi", Position = "Administrator", Email = "reza11@hotmail.com", Phone = "476-246-165" });
            members.Add(new Member { Number = "3", Character = "D", bgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Dennis Castillo", Position = "Coach", Email = "dent.cast@@gmail.com", Phone = "456-349-425" });
            members.Add(new Member { Number = "4", Character = "G", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Gabriel Cox", Position = "Coach", Email = "coxcox@gmail.com", Phone = "652-462-115" });
            members.Add(new Member { Number = "5", Character = "L", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Lena Jones", Position = "Manager", Email = "len.off@hotmail.com", Phone = "454-843-185" });
            members.Add(new Member { Number = "6", Character = "B", bgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Benjamin Caliword", Position = "Administrator", Email = "beni12@hotmail.com", Phone = "456-846-325" });
            members.Add(new Member { Number = "7", Character = "S", bgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Sophia Muris", Position = "Coach", Email = "sophi.muri@gmail.com", Phone = "476-449-129" });
            members.Add(new Member { Number = "8", Character = "A", bgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Ali Pormand", Position = "Manager", Email = "aliport@yahoo.com", Phone = "456-866-126" });
            members.Add(new Member { Number = "9", Character = "F", bgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Frank Underwood", Position = "Manager", Email = "frank@yahoo.com", Phone = "358-866-423" });
            members.Add(new Member { Number = "10", Character = "S", bgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Saeed Dasman", Position = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "436-846-129" });

            membersDataGrid.ItemsSource = members;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }
    }

    public class Member
    {
        public string Character { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Brush bgColor { get; set; }
    }
}
