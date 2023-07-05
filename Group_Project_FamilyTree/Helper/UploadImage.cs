using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_FamilyTree.Helper
{
	public class UploadImage
	{
		private readonly IWebHostEnvironment _environment;
		public UploadImage(IWebHostEnvironment environment) {
			_environment = environment;
		}
		public string GetImageFileName (IFormFile FileUpload)
		{
			string fileName;
			do
			{
				fileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUpload.FileName);
			} while (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, "image", fileName)));
			return fileName;
		}
		public async Task WriteImageFileAsync (IFormFile FileUpload, string fileName)
		{
			var file = Path.Combine(_environment.WebRootPath, "image", fileName);
			using (var fileStream = new FileStream(file, FileMode.Create))
			{
				await FileUpload.CopyToAsync(fileStream);
			}
		}public void DeleteImageFile (string fileName)
		{
			var file = Path.Combine(_environment.WebRootPath, "image", fileName);
			System.IO.File.Delete(file);
		}
	}
}
