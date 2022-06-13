using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Don2Loot
{
    public partial class NewTask : ContentPage
    {
           
        public NewTask()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, EventArgs e)
        {
            txtFileText.Text = "";
            txtFileName.Text = "";

        }
        protected async void Save(object sender, EventArgs e)
        {
            Task task = new Task();
            task.TaskDescription = txtFileText.Text;
            task.TaskName = txtFileName.Text;
            await App.Database.saveTask(task);
            List<Task> task1 = new List<Task>();
            task1 = await App.Database.getTask();
            DisplayAlert("Congrats!", "Note is saved!", "Go Back");
        }
        async void backButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}