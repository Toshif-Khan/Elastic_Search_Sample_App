using Nest;
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

namespace ElasticSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ElasticClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var node = new Uri("http://localhost:9200");

                var settings = new ConnectionSettings(
                    node
                ).DefaultIndex("my-app");

                client = new ElasticClient(settings);

                var persons = new [] {
                                        new Person
                                        {
                                            Id = "1",
                                            Firstname = "Martijn",
                                            Lastname = "Laarman"
                                        },

                                        new Person
                                        {
                                            Id = "2",
                                            Firstname = "Toshif",
                                            Lastname = "Khan"
                                        },

                                        new Person
                                        {
                                            Id = "3",
                                            Firstname = "Tosh",
                                            Lastname = "Mohammad"
                                        },

                                        new Person
                                        {
                                            Id = "4",
                                            Firstname = "Toheed",
                                            Lastname = "Pathan"
                                        },

                                        new Person
                                        {
                                            Id = "5",
                                            Firstname = "Mark",
                                            Lastname = "Benjamin"
                                        },

                                        new Person
                                        {
                                            Id = "6",
                                            Firstname = "Shoheb",
                                            Lastname = "Waris"
                                        }

                                    };

                foreach (var person in persons)
                {
                    var index = client.Index(person);
                }

                //var index = client.Index(person, i => i
                //                        .Index("another-index")
                //                        .Type("another-type")
                //                        .Id("1-should-not-be-the-id")
                //                        .Refresh()
                //                        .Ttl("1m")
                //                        );

                var searchResults = client.Search<Person>(s => s
                                                                .From(0)
                                                                .Size(10)
                                                                .Query(q => q
                                                                     .Term(p => p.Firstname, "toshif")
                                                                )
                                                            );

                //var searchResults = client.Search<Person>(s => s
                //                                                .From(0)
                //                                                .Size(10)
                //                                                .Query(q => q.QueryString(qs => qs.Query(textBox.Text + "*"))
                //                                                )
                //                                            );

                foreach (var hit in searchResults.Hits)
                {
                    Console.WriteLine("Name is : " + hit.Source.Firstname.ToString());
                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (rtxSearchResult.Text != "")
                {
                    rtxSearchResult.Clear();
                }
                var searchResults = client.Search<Person>(s => s
                                                                    .From(0)
                                                                    .Size(10)
                                                                    .Query(q => q.QueryString(qs => qs.Query(textBox.Text + "*"))
                                                                    )
                                                                );

                foreach (var hit in searchResults.Hits)
                {
                    Console.WriteLine("Name is : " + hit.Source.Firstname.ToString() + "\n");
                    rtxSearchResult.AppendText("Id : " + hit.Source.Id.ToString()
                        + Environment.NewLine
                        + "FirstName : " + hit.Source.Firstname.ToString()
                        + Environment.NewLine
                        + "LastName : " + hit.Source.Lastname.ToString()
                        + Environment.NewLine
                        + Environment.NewLine);
                }

                if (textBox.Text == "")
                {
                    rtxSearchResult.Clear();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                rtxSearchResult.Clear();
            }
        }
    }
}
