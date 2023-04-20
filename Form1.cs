using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Pobierz dane z OpenWeatherMap API
        private async Task<string> downloadWeather()
        {
            string city = textBox1.Text.ToLower();
            using var client = new HttpClient();
            string call = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=c5a9c8b10afea9b64ec48f629fe9ce1a";
            var response = await client.GetAsync(call);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
            try
            {
                var json = await downloadWeather();
                var weather = JsonSerializer.Deserialize<Weather>(json);
                textBox2.Text = "";
                textBox2.Text = $"Temperatura: {Math.Round((weather.main.temp - 273), 1)} C" + Environment.NewLine;
                textBox2.Text += $"Ciœnienie: {weather.main.pressure} hPa" + Environment.NewLine;
                textBox2.Text += $"Wilgotnoœæ: {weather.main.humidity} %" + Environment.NewLine;

                //Dodanie nowego miasta do bazy danych
            }
            catch
            {
                MessageBox.Show("Nie uda³o siê wczytaæ informacji o mieœcie. Spróbuj ponownie.");
            }
        }

    }
}