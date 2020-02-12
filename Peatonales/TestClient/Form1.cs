using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;

using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebApiFileUpload.DesktopClient
{
    public partial class Form1 : Form
    {
        //const string uploadServiceBaseAddress = "http://localhost:48697/api/fileupload";
        const string uploadServiceBaseAddress = "http://localhost:61253/api/MyFiles";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (textBox1.Visible)
            {
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            

            // Set the file dialog to filter for graphics files. 
            this.openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            // Allow the user to select multiple images. 
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Browse files to upload.";
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = this.openFileDialog1.ShowDialog();
        //    if (dr == System.Windows.Forms.DialogResult.OK)
        //    {
        //        try
        //        {
        //            HttpClient httpClient = new HttpClient();
        //            // Read the files 
        //            foreach (String file in openFileDialog1.FileNames)
        //            {

        //                var fileStream = File.Open(file, FileMode.Open);
        //                var fileInfo = new FileInfo(file);
        //                FileResult uploadResult = null;
        //                bool _fileUploaded = false;

        //                var content = new MultipartFormDataContent();
        //                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
        //                );
        //                Task taskUpload = httpClient.PostAsync(uploadServiceBaseAddress+ "/PrivatePicture", content).ContinueWith(task =>
        //                {
        //                    if (task.Status == TaskStatus.RanToCompletion)
        //                    {
        //                        var response = task.Result;

        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            //uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;
        //                            uploadResult = JsonConvert.DeserializeObject<FileResult>(response.Content.ReadAsAsync<string>().Result);
        //                            if (uploadResult != null)
        //                                _fileUploaded = true;

        //                            // Read other header values if you want..
        //                            foreach (var header in response.Content.Headers)
        //                            {
        //                                Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
        //                            Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
        //                        }
        //                    }

        //                    fileStream.Dispose();
        //                });

        //                taskUpload.Wait();
        //                if (_fileUploaded)
        //                    AddMessage(uploadResult.FileName + " with length " + uploadResult.FileLength
        //                                    + " has been uploaded at " + uploadResult.LocalFilePath);
        //            }

        //            httpClient.Dispose();
        //        }
        //        catch (Exception ex)
        //        {
        //            AddMessage(ex.Message);
        //        }
        //    }
        //}

        private void AddMessage(string message)
        {
            try
            {
                textBox1.AppendText(message);
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(Environment.NewLine);
            }
            catch
            {
            }
        }

        private void txtdownload_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
            FileResult fileresult = new FileResult() {
             LocalFilePath = "sYry+kKq4RzgVpp#mlnwvFuz17aZhDkt4y8X8xQ6wC+iRjmKKwPtGbApi2XLIXx9cxjJgblMBV0PZLV4JOof1gOZRZACo8zR9ROqGUirLU9+V96olnlCyyJiSTh#p4XqAKOIolz5elQ2taKzqWKfusmz#defRa7nrcmD+1VNUTzAPxPWXgFikJu3EwPndQAr"
             ,Qualitier = qual };

            //Task taskDownload= httpClient.GetAsync(uploadServiceBaseAddress + "/PrivatePicture",).ContinueWith(task =>
            string postBody = JsonConvert.SerializeObject(fileresult);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            Task taskDownload = httpClient.PostAsync(uploadServiceBaseAddress + "/DownloadPrivatePicture", new StringContent(postBody, Encoding.UTF8, "application/json")).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    var response = task.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var uploadResult = response.Content.ReadAsAsync<MediaTypeFormatter>().Result;

                        var stream = response.Content.ReadAsStreamAsync();
                        if (stream != null)
                        {
                            var img = Bitmap.FromStream(stream.Result);
                            pictureBox1.Image = img;
                        }
                            

                        // Read other header values if you want..
                        foreach (var header in response.Content.Headers)
                        {
                            Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
                        Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
                    }
                }

                //fileStream.Dispose();
            });

            taskDownload.Wait();

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = this.openFileDialog1.ShowDialog();
        //    if (dr == System.Windows.Forms.DialogResult.OK)
        //    {
        //        try
        //        {
        //            HttpClient httpClient = new HttpClient();
        //            // Read the files 
        //            foreach (String file in openFileDialog1.FileNames)
        //            {

        //                var fileStream = File.Open(file, FileMode.Open);
        //                var fileInfo = new FileInfo(file);
        //                FileResult uploadResult = null;
        //                bool _fileUploaded = false;

        //                var content = new MultipartFormDataContent();
        //                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
        //                );



        //                Task taskUpload = httpClient.PostAsync(uploadServiceBaseAddress + "/PrivateDocument", content).ContinueWith(task =>
        //                {
        //                    if (task.Status == TaskStatus.RanToCompletion)
        //                    {
        //                        var response = task.Result;

        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            //uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;
        //                            //object a=  response.Content.ReadAsAsync<string>().Result;
        //                            uploadResult = JsonConvert.DeserializeObject<FileResult>(response.Content.ReadAsAsync<string>().Result);
        //                            if (uploadResult != null)
        //                                _fileUploaded = true;

        //                            // Read other header values if you want..
        //                            foreach (var header in response.Content.Headers)
        //                            {
        //                                Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
        //                            Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
        //                        }
        //                    }

        //                    fileStream.Dispose();
        //                });

        //                taskUpload.Wait();
        //                if (_fileUploaded)
        //                    AddMessage(uploadResult.FileName + " with length " + uploadResult.FileLength
        //                                    + " has been uploaded at " + uploadResult.LocalFilePath);
        //            }

        //            httpClient.Dispose();
        //        }
        //        catch (Exception ex)
        //        {
        //            AddMessage(ex.Message);
        //        }
        //    }
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = this.openFileDialog1.ShowDialog();
        //    if (dr == System.Windows.Forms.DialogResult.OK)
        //    {
        //        try
        //        {
        //            HttpClient httpClient = new HttpClient();
        //            // Read the files 
        //            foreach (String file in openFileDialog1.FileNames)
        //            {

        //                var fileStream = File.Open(file, FileMode.Open);
        //                var fileInfo = new FileInfo(file);
        //                FileResult uploadResult = null;
        //                bool _fileUploaded = false;

        //                var content = new MultipartFormDataContent();
        //                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
        //                );



        //                Task taskUpload = httpClient.PostAsync(uploadServiceBaseAddress + "/PrivateSpreedsheet", content).ContinueWith(task =>
        //                {
        //                    if (task.Status == TaskStatus.RanToCompletion)
        //                    {
        //                        var response = task.Result;

        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            //uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;
        //                            uploadResult = JsonConvert.DeserializeObject<FileResult>(response.Content.ReadAsAsync<string>().Result);
        //                            if (uploadResult != null)
        //                                _fileUploaded = true;

        //                            // Read other header values if you want..
        //                            foreach (var header in response.Content.Headers)
        //                            {
        //                                Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
        //                            Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
        //                        }
        //                    }

        //                    fileStream.Dispose();
        //                });

        //                taskUpload.Wait();
        //                if (_fileUploaded)
        //                    AddMessage(uploadResult.FileName + " with length " + uploadResult.FileLength
        //                                    + " has been uploaded at " + uploadResult.LocalFilePath);
        //            }

        //            httpClient.Dispose();
        //        }
        //        catch (Exception ex)
        //        {
        //            AddMessage(ex.Message);
        //        }
        //    }
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    DialogResult dr = this.openFileDialog1.ShowDialog();
        //    if (dr == System.Windows.Forms.DialogResult.OK)
        //    {
        //        try
        //        {
        //            HttpClient httpClient = new HttpClient();
        //            // Read the files 
        //            foreach (String file in openFileDialog1.FileNames)
        //            {

        //                var fileStream = File.Open(file, FileMode.Open);
        //                var fileInfo = new FileInfo(file);
        //                FileResult uploadResult = null;
        //                bool _fileUploaded = false;

        //                var content = new MultipartFormDataContent();
        //                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
        //                );
        //                Task taskUpload = httpClient.PostAsync(uploadServiceBaseAddress + "/PublicPicture", content).ContinueWith(task =>
        //                {
        //                    if (task.Status == TaskStatus.RanToCompletion)
        //                    {
        //                        var response = task.Result;

        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            //uploadResult = response.Content.ReadAsAsync<FileUploadResult>().Result;
        //                            uploadResult = JsonConvert.DeserializeObject<FileResult>(response.Content.ReadAsAsync<string>().Result);
        //                            if (uploadResult != null)
        //                                _fileUploaded = true;

        //                            // Read other header values if you want..
        //                            foreach (var header in response.Content.Headers)
        //                            {
        //                                Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
        //                            Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
        //                        }
        //                    }

        //                    fileStream.Dispose();
        //                });

        //                taskUpload.Wait();
        //                if (_fileUploaded)
        //                    AddMessage(uploadResult.FileName + " with length " + uploadResult.FileLength
        //                                    + " has been uploaded at " + uploadResult.LocalFilePath);
        //            }

        //            httpClient.Dispose();
        //        }
        //        catch (Exception ex)
        //        {
        //            AddMessage(ex.Message);
        //        }
        //    }
        //}

        private void button7_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };

            FileResult fileresult = new FileResult()
            {
                LocalFilePath = "sYry+kKq4RzgVpp#mlnwvFuz17aZhDkt4y8X8xQ6wC+iRjmKKwPtGbApi2XLIXx9cxjJgblMBV0PZLV4JOof1gOZRZACo8zR9ROqGUirLU9+V96olnlCyyJiSTh#p4Xqmxi4iaSnvQt7tvwbSP+ZfYZTz3JHuc5yRyUaFsCGckM="
             ,
                Qualitier = qual
            };

            //Task taskDownload= httpClient.GetAsync(uploadServiceBaseAddress + "/PrivatePicture",).ContinueWith(task =>
            string postBody = JsonConvert.SerializeObject(fileresult);


            //Task taskDownload = httpClient.GetAsync(uploadServiceBaseAddress + "/PublicPicture").ContinueWith(task =>
            //string postBody = JsonConvert.SerializeObject(qual);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            Task taskDownload = httpClient.PostAsync(uploadServiceBaseAddress + "/DownloadPublicPicture", new StringContent(postBody, Encoding.UTF8, "application/json")).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    var response = task.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var uploadResult = response.Content.ReadAsAsync<MediaTypeFormatter>().Result;

                        var stream = response.Content.ReadAsStreamAsync();
                        if (stream != null)
                        {
                            var img = Bitmap.FromStream(stream.Result);
                            pictureBox2.Image = img;
                        }


                        // Read other header values if you want..
                        foreach (var header in response.Content.Headers)
                        {
                            Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
                        Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
                    }
                }

                //fileStream.Dispose();
            });

            taskDownload.Wait();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
            //Task taskDownload = httpClient.GetAsync(uploadServiceBaseAddress + "/PublicPicture").ContinueWith(task =>
            string postBody = JsonConvert.SerializeObject(qual);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            Task taskDownload = httpClient.PostAsync(uploadServiceBaseAddress + "/DownloadPrivateDocument",new StringContent("")).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    var response = task.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var uploadResult = response.Content.ReadAsAsync<MediaTypeFormatter>().Result;

                        var stream = response.Content.ReadAsStreamAsync();
                        if (stream != null)
                        {
                            var img = Bitmap.FromStream(stream.Result);
                            pictureBox2.Image = img;
                        }


                        // Read other header values if you want..
                        foreach (var header in response.Content.Headers)
                        {
                            Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
                        Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
                    }
                }

                //fileStream.Dispose();
            });

            taskDownload.Wait();
        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            Qualitiers qual = new Qualitiers() { Fitmode = FitMode.Stretch, Height = 20, Widht = 30, Quality = 100 };
            //Task taskDownload = httpClient.GetAsync(uploadServiceBaseAddress + "/PublicPicture").ContinueWith(task =>
            string postBody = JsonConvert.SerializeObject(qual);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/hal+json"));
            Task taskDownload = httpClient.PostAsync(uploadServiceBaseAddress + "/DownloadPrivateSpreedSheet", new StringContent("")).ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    var response = task.Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var uploadResult = response.Content.ReadAsAsync<MediaTypeFormatter>().Result;

                        var stream = response.Content.ReadAsStreamAsync();
                        if (stream != null)
                        {
                            var img = Bitmap.FromStream(stream.Result);
                            pictureBox2.Image = img;
                        }


                        // Read other header values if you want..
                        foreach (var header in response.Content.Headers)
                        {
                            Debug.WriteLine("{0}: {1}", header.Key, string.Join(",", header.Value));
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
                        Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
                    }
                }

                //fileStream.Dispose();
            });

            taskDownload.Wait();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string r = this.Encypt("134679852Tt2017");
            string d = this.Decrypt(r);
            string be = "da";
            //string sinacento = RemoveAcentuation(textBox2.Text);
            //string b;
        }

        public string RemoveAcentuation(string text)
        {
            return
                System.Web.HttpUtility.UrlDecode(
                    System.Web.HttpUtility.UrlEncode(
                        text, Encoding.GetEncoding("iso-8859-7")));
        }

        public String Encypt(String stringToCypher)
        {
            byte[] byteString = Encoding.Unicode.GetBytes(stringToCypher);
            return Convert.ToBase64String(byteString);
        }

        public String Decrypt(String stringToDecipher)
        {
            byte[] byteString = Convert.FromBase64String(stringToDecipher);
            return Encoding.Unicode.GetString(byteString);
        }
    }
}
