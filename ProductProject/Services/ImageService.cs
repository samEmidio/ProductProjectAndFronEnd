using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProductProject.Services.Interface;

namespace ProductProject.Services
{
    public class ImageService : IImage
    {
        private readonly IWebHostEnvironment iWebHostEnvironment;

        public ImageService(IWebHostEnvironment iWebHostEnvironment)
        {
            this.iWebHostEnvironment = iWebHostEnvironment;
        }


        public List<string> saveImage(IFormFileCollection iFormFileCollection)
        {   
            string path = this.iWebHostEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString()
            +"Resources"+Path.DirectorySeparatorChar.ToString();

            List<string> files = new List<string>();

            foreach(var file in iFormFileCollection)
            {
                string name =  DateTime.Now.Ticks.ToString() +"_"+file.FileName;  
                
                FileStream fParameter = new FileStream(path+name, FileMode.Create, FileAccess.Write);
                file.CopyTo(fParameter);  
                StreamWriter m_WriterParameter = new StreamWriter(fParameter);  
                m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
                m_WriterParameter.Flush();  
                m_WriterParameter.Close();

                files.Add(name);

            }

            return files;
        }
    }
}