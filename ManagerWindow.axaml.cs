using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoExam.Context;
using DemoExam.Views;
using Microsoft.EntityFrameworkCore;

namespace DemoExam;

public partial class ManagerWindow : Window
{
    public ManagerWindow()
    {
        InitializeComponent();
        Show_Name();
    }
    private async void Show_Name()
    {
        PostgresContext context = new PostgresContext();
        var user = await context.Users.FirstOrDefaultAsync();
        FIO.Text = user.UserLastname + user.UserName + user.UserSurname;
    }
    private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new LoginWindow().Show();
        this.Close();
    }

    private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
    }
}