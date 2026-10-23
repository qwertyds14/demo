using Avalonia.Controls;
using DemoExam.Context;
using DemoExam.Models;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;

namespace DemoExam.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // обращаемся к контексту и сверяем логины (по условию задачи без пароля). в случае если такого пользователя нет,
        // вывести messagebox с ошибкой, а иначе открыть нужное окно обращаясь по RoleId)
        private async void Login_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            PostgresContext context = new PostgresContext();
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserLogin == LoginBox.Text);
            if (user == null)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Неверный логин");
                await box.ShowAsync();
            }
            else if (user.RoleId == 3)
            {
                new UserWindow().Show();
                this.Close();
            }
            else if (user.RoleId == 2)
            {
                new ManagerWindow().Show();
                this.Close();
            }
            else if(user.RoleId == 1)
            {
                new AdminWindow().Show();
                this.Close();
            }

        }

        private void Guest_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            new GuestWindow().Show();
            this.Close();
        }
    }
}