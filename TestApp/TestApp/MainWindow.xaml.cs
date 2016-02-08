using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtensionMethods;
using RandomOrgApi;
using System.Reflection;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RandomAPINumberGenerator rand = new RandomAPINumberGenerator();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string hello = "Test Clone method";
            OutputTextBlock.Text = "Object: " + Environment.NewLine + hello + Environment.NewLine;
            OutputTextBlock.Text += "Cloning the object..." + Environment.NewLine ;
            var strCL = hello.Clone();
            OutputTextBlock.Text += "Object clone:" + Environment.NewLine + strCL + Environment.NewLine + Environment.NewLine ;
            OutputTextBlock.Text += "Cloning the object..." + Environment.NewLine;
            var str = "String Clone".Clone();
            var v = new object().Clone();
            OutputTextBlock.Text += "Object clone:" + Environment.NewLine + str + Environment.NewLine;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OutputTextBlock.Text = "Test generator of random numbers" + Environment.NewLine + Environment.NewLine;
            int n = rand.GetNumber(7);
            OutputTextBlock.Text += "Random number: " + n + Environment.NewLine;
            int length = rand.randQueue.Count;
            OutputTextBlock.Text += "Queue length: " + length + Environment.NewLine + "Random.org is available: " + rand.randOrgIsAvailable;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OutputTextBlock.Text = "Test default ctors" + Environment.NewLine + Environment.NewLine;
            OutputTextBlock.Text += "Wait..." + Environment.NewLine + Environment.NewLine;
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            if (!MyGlobals.alreadyChecked) { 
                foreach (Assembly asm in assemblies)
                {
                    Type[] types = asm.GetTypes();
                    foreach (Type t in types)
                    {
                        ConstructorInfo ctor = t.GetConstructor(Type.EmptyTypes);
                        if (ctor != null)
                        {
                            MyGlobals.ctorList.Add(t, ctor);
                        }
                    }
                }
            }
            MyGlobals.alreadyChecked = true;
            Type testType = typeof(Book);
            Book book = testType.Create<Book>();
            book.Title = "Title of created Book object";
            OutputTextBlock.Text +=  book.Title;

        }
    }

    public static class MyGlobals
    {
        public static bool alreadyChecked = false;
        public static Dictionary<Type, ConstructorInfo> ctorList = new Dictionary<Type, ConstructorInfo>();
    }
    public static class TypeExtension
    {
        public static T Create<T>(this Type type)
        {
            object obj = MyGlobals.ctorList[type].Invoke(new object[] { });
            T result = (T)Convert.ChangeType(obj, typeof(T));
            return result;
        }
    }
}
