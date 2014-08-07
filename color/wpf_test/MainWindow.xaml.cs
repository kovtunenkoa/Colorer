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
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;


namespace wpf_test
{

 
    public class MyColor 
    {
        public MyColor(System.Drawing.Color color)
        {
            _color = color;
        }

        private System.Drawing.Color _color;
        public string Name
        {
            get { return _color.Name; }
        }
    }


    
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BrushConverter converter = new BrushConverter();
            System.Windows.Media.Brush brush = (System.Windows.Media.Brush)converter.ConvertFromString((string)value);
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ColorViewModel :UserControl, INotifyPropertyChanged
    {
        

        private ObservableCollection<MyColor> _MyColors;
        public ObservableCollection<MyColor> MyColors { get { return _MyColors; } set { _MyColors = value; OnPropertyChanged("MyColors"); } }
        public ColorViewModel(FrameworkElement window)
        {
            Window = window;
            cmdShow = new RoutedCommand();
            CommandManager.RegisterClassCommandBinding(Window.GetType(), new CommandBinding(cmdShow, cmdShow_Click));
            FillColors();
        }

                     
        private void FillColors()
        { 
            this.MyColors = new ObservableCollection<MyColor>();
             for (int i = 0; i < 400; i++)
                 this.MyColors.Add(new MyColor(NextColor()));
        }

        
        protected void cmdShow_Click(object sender, ExecutedRoutedEventArgs e)
        {
           MyColor selectedData = e.Parameter as MyColor;
           
            var mf = Application.Current.Windows[0] as MainWindow;
            if (mf != null)
                mf.txtBlock.Text ="Selected color:" + "\n" +  selectedData.Name;               
        } 

        private Random rand = new Random();
        private Type colorType = typeof(System.Drawing.Color);
        private PropertyInfo[] propInfo;
        private FrameworkElement Window { get; set; }
        public ICommand cmdShow { get; set; } 

        private System.Drawing.Color NextColor()
        {
            propInfo = colorType.GetProperties(BindingFlags.Static | BindingFlags.Public);
            System.Drawing.Color ColorName = System.Drawing.Color.FromName(propInfo[rand.Next(0, propInfo.Length)].Name);

            return ColorName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ColorViewModel cvm = new ColorViewModel(this);
            this.DataContext = cvm;
        }
        
    }
}
