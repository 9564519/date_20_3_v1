using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

class Program
{
    static void Main()
    {
        DateTime currentDate = DateTime.Now;
        int currentDay = currentDate.Day;

        string dataFilePath = "lastMessageDate.txt";

        if (currentDay >= 4) // Если текущая дата 6-ое число или больше
        {
            if (File.Exists(dataFilePath))
            {
                string lastMessageDate = File.ReadAllText(dataFilePath);
                if (currentDate.ToString("yyyy-MM") == lastMessageDate)
                {
                    return; // Если данные совпадают, завершаем программу
                }
            }

            // Создание и отображение окна с текстовым сообщением на весь экран
            Form messageForm = new Form()
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                BackColor = System.Drawing.Color.Black // Установка черного цвета фона
            };

            Label label = new Label()
            {
                Text = "ВОДА!\n\n20 сегодня\nили уже прошло!\nСдай данные\nПо воде!",
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 40, System.Drawing.FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter, // Выравнивание текста по центру
                Dock = DockStyle.Fill,
                ForeColor = System.Drawing.Color.White,
                Anchor = AnchorStyles.None // Центрируем относительно формы
            };

            messageForm.Controls.Add(label);
            messageForm.ShowDialog();

            // Сохранение текущей даты в файл
            File.WriteAllText(dataFilePath, currentDate.ToString("yyyy-MM"));
        }
        else
        {
            return; // завершаем программу
        }
    }
}
