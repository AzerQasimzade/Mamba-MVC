using MambaTemplate.Utilities.Enums;

namespace MambaTemplate.Utilities.Extensions
{
    public static class FileValidator
    {
        public static bool ValidateFileType(this IFormFile file,FileHelper type)
        {
            if (type == FileHelper.Image)
            {
                if (file.ContentType.Contains("image/"))
                {
                    return true;
                }
                return false;
            }
            else if (type == FileHelper.Video)
            {
                if (file.ContentType.Contains("video/"))
                {
                    return true;
                }
                return false;
            }
            else if (type == FileHelper.Audio)
            {
                if (file.ContentType.Contains("audio/"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool ValidateSize(this IFormFile file,SizeHelper size)
        {
            long filesize = file.Length;
            switch (size)
            {
                case SizeHelper.kb:
                   return filesize <= 1024; 
                case SizeHelper.mb:
                    return filesize <= 1024*1024;
                case SizeHelper.gb:
                    return filesize <= 1024*1024*1024;
            }
            return false;   
        }
        public async static void DeleteFile(this string filename,string root, params string[] folders)
        {
            string path = root;
            for (int i = 0; i < folders.Length; i++)
            {
                Path.Combine(path, folders[i]);
            }
            path= Path.Combine(path,filename);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

}
