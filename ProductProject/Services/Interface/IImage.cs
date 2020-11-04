using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProductProject.Services.Interface
{
    public interface IImage
    {
        List<string> saveImage(IFormFileCollection iFormFileCollection);
    }
}