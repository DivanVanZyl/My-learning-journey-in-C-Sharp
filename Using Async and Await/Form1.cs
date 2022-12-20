using System.Net;

namespace Using_Async_and_Await
{
    public partial class Form1 : Form
    {
        //synchronous
        public int CalculateValue()
        {
            Thread.Sleep(5000);
            return 123;
        }
        //asynchronous
        public Task<int> CalculateValueAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return 123;
            });
        }
        public async Task<int> CalculateValueAsyncFinal()
        {
            await Task.Delay(5000);
            return 123;
            
        }
        //synchronous with async/await keywords
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            /*int n = CalculateValue();
            lblResult.Text = n.ToString();*/

            /*var calculation = CalculateValueAsync();
            calculation.ContinueWith(t =>
            {
                lblResult.Text = t.Result.ToString();

            }, TaskScheduler.FromCurrentSynchronizationContext());*/

            int value = await CalculateValueAsyncFinal();
            lblResult.Text = value.ToString();  //Executed on UI Thread. 

            await Task.Delay(5000);

            //IMPORTANT: As soon as the "await" happens, we are releasing the entire UI thread.
            //The "await" statements you see happening here, does not happen on the UI thread. The  "lblResult.Text = ..." statements are executed on the UI thread.
            using (var wc = new WebClient())
            {
                string data = await
                    wc.DownloadStringTaskAsync("http://google.com/robots.txt");
                lblResult.Text = data.Split('\n')[0].Trim();
            }
        }
    }
}