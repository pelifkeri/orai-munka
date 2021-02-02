using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace WinFormsHttpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            try
            {
                //using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users"))

                var user = new User { Id = 123, Name = "Géza" };
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:59621/minta", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string valasz = await response.Content.ReadAsStringAsync();
                        //var eredmeny = JsonConvert.DeserializeObject<List<User>>(valasz);
                        //MessageBox.Show(eredmeny[0].Felhasznalonev);
                        MessageBox.Show(valasz);
                    }
                    else
                    {
                        MessageBox.Show(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
    }
}
