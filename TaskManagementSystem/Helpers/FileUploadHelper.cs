using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Helpers
{
    public class FileUploadHelper
    {
        public static string SaveFile(HttpPostedFileBase file, string folderPath)
        {
            if (file == null)
            {
                return null;
            }

            try
            {
                // Ensure the folder path ends with a directory separator.
                if (!folderPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    folderPath += Path.DirectorySeparatorChar;
                }

                // Generate a unique file name to avoid overwriting existing files.
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // Combine the folder path and the unique file name to create the full file path.
                string filePath = Path.Combine(folderPath, uniqueFileName);

                // Save the file to the specified path.
                file.SaveAs(filePath);

                // Return the relative path to the saved file.
                return filePath;
            }
            catch (Exception)
            {
                // Handle any errors that may occur during file upload.
                return null;
            }
        }
    }
}