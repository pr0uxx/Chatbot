using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("English.xml"))
            {
                return;
            }
            else
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = (" ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = true;
                settings.NewLineOnAttributes = true;
                using (XmlWriter writer = XmlWriter.Create("English.xml", settings))
                {
                    
                    writer.WriteStartElement("Word");
                    writer.WriteElementString("Value", "Open");
                    writer.WriteElementString("Tier", "Tier1");
                    writer.WriteElementString("Class", "Command");
                    writer.WriteElementString("Response", "OpenExe");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            

        }

        //Here's where the magic starts

        //Variables that are used to deconstruct sentences
        
        //Variables for building responses 
        string[] noinput = { "I need you to write something before you press the button", "I might be good, but I'm not psychic" };
       
        
        protected void Click_Go(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Go.Text))
            {
                outputText.Text = noinput[new Random().Next(0,noinput.Length)];
            }
            else
            { }
        }

        private void _Go_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }

}
