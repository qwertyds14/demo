using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam.Context;
using DemoExam.Models;
using DemoExam.Views;
using System.Linq;

namespace DemoExam;

public partial class GuestWindow : Window
{
    public GuestWindow()
    {
        InitializeComponent();
        Product_list();
    }
    // метод поиска.
    private async void Product_list()
    {
        PostgresContext context = new PostgresContext();
        var products = context.Products.ToList();
        // if (SearchBox.Text != null && SearchBox.Text != "")
        {
            
        }
    }

    private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new LoginWindow().Show();
        this.Close();
    }

    private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        Product_list();
    }
}