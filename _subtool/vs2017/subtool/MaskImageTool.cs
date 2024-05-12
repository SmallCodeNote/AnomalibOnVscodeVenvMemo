using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MaskImageTool
{
    static class MaskImage
    {
        static public void CreateFromMarkColor(string targetFilePath)
        {
            CreateMarkFromColor(targetFilePath, 255, 0, 0);
        }

        static public void CreateMarkFromColor(string targetFilePath,byte mR,byte mG,byte mB)
        {
            Bitmap originalImage = new Bitmap(targetFilePath);
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    if (originalColor.R == mR && originalColor.G == mG && originalColor.B == mB)
                    {
                        newImage.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        newImage.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

            string directory = Path.GetDirectoryName(targetFilePath);
            string oldFileName = Path.GetFileName(targetFilePath);
            string newFileName = "_" + oldFileName;
            File.Move(targetFilePath, Path.Combine(directory, newFileName));

            newImage.Save(targetFilePath);

            Bitmap compositeImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    Color newColor = newImage.GetPixel(x, y);

                    int r = (originalColor.R + newColor.R) / 2;
                    int g = (originalColor.G + newColor.G) / 2;
                    int b = (originalColor.B + newColor.B) / 2;

                    compositeImage.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            compositeImage.Save(Path.Combine(directory, "x" + oldFileName));
        }

        static public void CreateMarkFromDifference(string baseDataDirPath, string editDataDirPath, string maskDataDirPath, int threshold)
        {
            var editFiles = Directory.GetFiles(editDataDirPath, "*.*");
            foreach (var editFile in editFiles)
            {
                var fileName = Path.GetFileName(editFile);
                var baseFile = Path.Combine(baseDataDirPath, fileName);
                if (File.Exists(baseFile))
                {
                    using (var img1 = new Bitmap(baseFile))
                    using (var img2 = new Bitmap(editFile))
                    {
                        var img3 = new Bitmap(img1.Width, img1.Height);
                        for (int x = 0; x < img1.Width; x++)
                        {
                            for (int y = 0; y < img1.Height; y++)
                            {
                                var pixel1 = img1.GetPixel(x, y);
                                var pixel2 = img2.GetPixel(x, y);
                                var diff = Math.Abs(pixel1.R - pixel2.R) + Math.Abs(pixel1.G - pixel2.G) + Math.Abs(pixel1.B - pixel2.B);
                                if (diff >= threshold)
                                {
                                    img3.SetPixel(x, y, Color.White);
                                }
                                else
                                {
                                    img3.SetPixel(x, y, Color.Black);
                                }
                            }
                        }
                        img3.Save(Path.Combine(maskDataDirPath, fileName));
                    }
                }
            }
        }

    }
}
