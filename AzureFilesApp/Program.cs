using Microsoft.WindowsAzure.Storage;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace AzureFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConnectionSting = ConfigurationManager.ConnectionStrings["AzureStorageAccount"].ConnectionString;

            Console.WriteLine(@"Connecting to Azure Storage Account");

            CloudStorageAccount sa = CloudStorageAccount.Parse(strConnectionSting);

            Console.WriteLine(@"Connected To Azure Storage Account");

            Console.WriteLine(@"Cheking Cloud Storage File Location");
            
            //Create Azure File Share             
            var share = sa.CreateCloudFileClient().GetShareReference("myfilesonazure");
            share.CreateIfNotExists();

            Console.WriteLine(@"Cloud Location Found On Azure");
            Console.WriteLine(@"Preparing Content For File");

            //File Name and Content Information
            string TempFileName = DateTime.Now.Second.ToString() + ".html";
            string content = @"<!DOCTYPE html><html><body><h2>HTML Forms</h2><form action='/action_page.php'>  First name:<br>  <input type='text' name='firstname' value='Nilesh'>  <br>  Last name:<br><input type='text' name='lastname' value='Rathod'><br><br>  <input type='submit' value='Submit'></form></body></html>";

            Console.WriteLine(@"File Content Completed");

            Console.WriteLine(@"Adding File On Cloud Location");

            ////Create File in Root Folder 
            var rootDir = share.GetRootDirectoryReference();            
            var fileToCreate = rootDir.GetFileReference(TempFileName);
            fileToCreate.UploadText(content);

            Console.WriteLine(@"File Successfully Uploaded On Cloud Location");

        }

    }
}
