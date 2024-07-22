namespace GoodReadsClone.Application.Helpers;

public class FileManager
{
    public const string ProfilePicturesPath = "\\images\\profile-pictures";
    public const string BooksCoversPath = "\\images\\books-covers";

    public const string ValidImageFormats = "jpg,jpeg,png";
    public const int MaxImageSizeInMB = 3;


    public static string UpsertImage(IFormFile? file, string wwwRootPath, string directoryPath, string ImageUrl = default!)
    {
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string imagePath = Path.Combine(wwwRootPath, directoryPath);

        if (!string.IsNullOrEmpty(ImageUrl))
        {
            // Delete the old image
            string oldImagePath =
                Path.Combine(wwwRootPath, ImageUrl.TrimStart('\\'));


            if (File.Exists(oldImagePath))
                File.Delete(oldImagePath);
        }

        using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return @$"\{directoryPath}\{fileName}";
    }

    public static bool IsValidFormat(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file.Name);
        var validExtensions = ValidImageFormats.Split(',');
        return validExtensions.Contains(fileExtension);
    }

    public static bool IsValidImageSize(IFormFile file)
    {
        return file.Length <= MaxImageSizeInMB * 1024 * 1024;
    }

}
