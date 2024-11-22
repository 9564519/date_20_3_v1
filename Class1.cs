using System;
using System.IO;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        DateTime currentDate = DateTime.Now;
        int currentDay = currentDate.Day;

        string dataFilePath = "lastMessageDate.txt";

        if (currentDay >= 20) // Если текущая дата 20-тое число или больше
        {
            string lastMessageDate = File.Exists(dataFilePath) ? File.ReadAllText(dataFilePath) : "";

            if (currentDate.ToString("yyyy-MM") != lastMessageDate)
            {
                // Создание и отображение окна с текстовым сообщением на весь экран
                Form messageForm = new Form()
                {
                    Text = "Тестовое сообщение",
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized
                };
                Label label = new Label()
                {
                    Text = "Тестовое сообщение",
                    AutoSize = true,
                    Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                messageForm.Controls.Add(label);
                messageForm.ShowDialog();

                // Сохранение текущей даты в файл
                File.WriteAllText(dataFilePath, currentDate.ToString("yyyy-MM"));
            }
        }

        // Блокировка закрытия программы
        bool allowClose = false;
        Form closingConfirmationForm = new Form()
        {
            Text = "Подтверждение закрытия",
            Size = new System.Drawing.Size(300, 100)
        };
        Label message = new Label()
        {
            Text = "Вы уверены, что хотите закрыть программу?",
            AutoSize = true,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter
        };
        Button closeButton = new Button()
        {
            Text = "Закрыть",
            DialogResult = DialogResult.OK
        };
        closeButton.Click += (sender, e) => { allowClose = true; closingConfirmationForm.Close(); };
        closingConfirmationForm.Controls.Add(message);
        closingConfirmationForm.Controls.Add(closeButton);

        Application.ApplicationExit += (sender, e) =>
        {
            if (!allowClose)
            {
                closingConfirmationForm.ShowDialog();
            }
        };

        Application.Run();
    }
}
