using Plugin.LocalNotification;
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
            int taskId = task1[task1.Count() - 1].Id;
            await DisplayAlert("Congrats!", "Note is saved!", "Go Back");
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "How did you do on " + task1[task1.Count() - 1].TaskName.ToLower() + "?",
                Title = task1[task1.Count() - 1].TaskName.ToUpper(),
                ReturningData = taskId.ToString(),
                NotificationId = taskId,
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(5),
                    RepeatType = NotificationRepeat.Daily
                }
            };

            await NotificationCenter.Current.Show(notification);
        }
        async void backButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}